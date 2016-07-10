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
                Session["New"] = txbUserName.Text.Trim();
                Session["UserId"] = userId;
                Response.Redirect("~/Main.aspx");
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
                
    }
}