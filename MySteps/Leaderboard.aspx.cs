using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Leaderboard : System.Web.UI.Page
{
    string userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the user is login in the system
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }

        userId = Session["UserId"].ToString();
        Session["DateTime"] = DateTime.Now;
        Session["today"] = DateTime.Today.Date;



       // string str = "SELECT * From PhysicalActivityData where DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

        string str = "SELECT DailySteps, UserData.UserName From PhysicalActivityData INNER JOIN UserData ON PhysicalActivityData.UserID = UserData.Id where DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter(str,conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        ListView1.DataSource = dt;
        ListView1.DataBind();



        

    }
}