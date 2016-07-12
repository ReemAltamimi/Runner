using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class LoginPage : System.Web.UI.Page
{
    //create a string of control group participants.
    string[] controlGroup = new string[] { "G1B1", "G1B2", "G1B3", "G1B4", "G1B5", "CAdmin" };
    //create a string of experiment group participants.
    string[] experimentGroup = new string[] {"G1B6", "G1B7", "G1B8", "G1B9", "G1B10", "EAdmin" };

    string groupName;


    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#FF8080");

        //Place the cursor in username textbox
        txbUserName.Focus();       

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int userId;

        try
        {
            //call checkLogin function in UserData class to check if the user name and password is correct
            //and return the user id
            userId = UserData.checkLogin(txbUserName.Text, txbPassword.Text);

            //user name or password are incorrect
            if (userId == 0)
            {
                Label2.Text = "Error: User name or password is not correct ..";
                txbUserName.Text = "";
                txbPassword.Text = "";
            }
            //user name and password are correct
            else
            {
                string bandCode = UserData.getBandCode(userId);
                string shareAuth = UserData.getShareAuth(userId).Trim();

                groupName = checkGroup(bandCode.Trim());

                Session["New"] = txbUserName.Text.Trim();
                Session["UserId"] = userId;
                Session["GroupName"] = groupName.Trim();
                Session["ShareAuth"] = shareAuth;
                Response.Redirect("~/Main.aspx");
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
                
    }

    //Function to check the group name of the participant

    private string checkGroup(string user)
    {
        string group;

        bool found = controlGroup.Contains(user);

        if (found)
            group = "Control";
        else
            group = "Experiment";

        return group;
    }

}