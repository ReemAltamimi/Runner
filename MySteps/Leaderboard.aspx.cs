using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class Leaderboard : System.Web.UI.Page
{
    string userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#80FF80");

        //check if the user is login in the system
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }

        userId = Session["UserId"].ToString();
        Session["DateTime"] = DateTime.Now;
        Session["today"] = DateTime.Today.Date;

        try
        {

            if(Session["GroupName"].ToString().Equals("Control"))
            {
                //fill the list view with all users'names and their steps of today
                string str = "SELECT DailySteps, UserData.UserName From PhysicalActivityData INNER JOIN UserData ON PhysicalActivityData.UserID = UserData.Id where UserData.Share = 'Y' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter(str, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListView2.DataSource = dt;
                ListView2.DataBind();
            }
            else
            {
                //check if the user plays game or not
                bool found = Game.gameDayRecordExists(Convert.ToInt32(userId));
                if (found == false)
                {
                    Game.insertGameData(Convert.ToInt32(userId), DateTime.Now, 0, Game.DEFAULT_TIME);
                }
                //fill the list view with all users'names and their steps of today and their game levels
                string str = "SELECT DailySteps, UserData.UserName, MAX(GameData.UnLockedLevel) as UnLockedLevel From PhysicalActivityData INNER JOIN UserData ON PhysicalActivityData.UserID = UserData.Id INNER JOIN GameData ON PhysicalActivityData.UserID = GameData.UserID where UserData.Share = 'Y' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE())) Group by PhysicalActivityData.DailySteps, UserData.UserName, UserData.Id";

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
                SqlDataAdapter sda = new SqlDataAdapter(str, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }

           

        }
        catch (Exception exp)
        {
            lblAbout.Text = "Exception caught: " + exp; 
        }

      
    }
}