using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class PA_Vs_ST : System.Web.UI.Page
{
    string userId;
    DateTime lastTimeST;
    DateTime lastTimePA;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["New"] == null)
            Response.Redirect("~/LoginPage.aspx");

        userId = Session["UserId"].ToString();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
        conn.Open();
       
        //select the last time of updated screen time in date column that match the current session user id and in the date of today
        string checkLastTime1 = "select Max(DateAndTime) from PA_And_ST where UserID= '" + Session["UserId"] + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))"
            + "AND UserDailyAmnt is not null";
        SqlCommand command1 = new SqlCommand(checkLastTime1, conn);
        lastTimeST = Convert.ToDateTime(command1.ExecuteScalar());

        //select the last time of updated Physical Activity in date column that match the current session user id and in the date of today
        string checkLastTime2 = "select Max(DateAndTime) from PA_And_ST where UserID= '" + Session["UserId"] + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))"
            + "AND DailySteps is not null";
        SqlCommand command2 = new SqlCommand(checkLastTime2, conn);
        lastTimePA = Convert.ToDateTime(command2.ExecuteScalar());

        conn.Close();

        //set the last time for chart data customization
        Session["LastTimeST"] = lastTimeST;
        Session["LastTimePA"] = lastTimePA;

        //to limit the axis X data
        double startDate = DateTime.Now.AddDays(-1).ToOADate();
        double endDate = DateTime.Now.AddDays(1).ToOADate();

        //limit the values that appear in x axis 
        PA_Versus_ST.ChartAreas["ChartArea1"].AxisX.Minimum = startDate;
        PA_Versus_ST.ChartAreas["ChartArea1"].AxisX.Maximum = endDate;
        //to show each single day in x axis
        PA_Versus_ST.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        //to show the x axis labels vertically
        PA_Versus_ST.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 90;
        //set the width of series column in the chart
        PA_Versus_ST.Series["UserScreenAmount"]["PixelPointWidth"] = "100";
        PA_Versus_ST.Series["RecommendedScreenAmount"]["PixelPointWidth"] = "100";
        PA_Versus_ST.Series["UserPhysicalSteps"]["PixelPointWidth"] = "100";
        PA_Versus_ST.Series["RecommendedStepsBoys"]["PixelPointWidth"] = "100";
        PA_Versus_ST.Series["RecommendedStepsGirls"]["PixelPointWidth"] = "100";

        //Place Axis titles
        PA_Versus_ST.ChartAreas[0].AxisX.Title = "Date";
        PA_Versus_ST.ChartAreas[0].AxisY.Title = "Screen Time (Hours), Physical Activity (Steps)";



        Label2.Text = "Last updated for screen time " + lastTimeST.ToString() + "<br />"+ "Last updated for Physical activity " + lastTimePA.ToString();

    }
}