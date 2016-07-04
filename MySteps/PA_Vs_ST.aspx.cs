using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class PA_Vs_ST : System.Web.UI.Page
{
    string userId;
    DateTime lastTimeST;
    DateTime lastTimePA;

    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#80FF80");

        if (Session["New"] == null)
            Response.Redirect("~/LoginPage.aspx");

        userId = Session["UserId"].ToString();

        int stFound = ScreenTime.screenTimeIsEntered(Convert.ToInt32(userId));
        int paFound = PhysicalActivity.physicalActivityIsEntered(Convert.ToInt32(userId));

        if (stFound == 0)
        {
            Label1.Text = "You have not entered your screen data today";
        }
        else if (paFound == 0)
        {
            Label1.Text = "You have not sync your physical activity data";
        }
        else
        {
            lastTimeST = ScreenTime.getLastTimeInserted(Convert.ToInt32(userId));
            lastTimePA = PhysicalActivity.getLastTimeInserted(Convert.ToInt32(userId));

            //set the last time for chart data customization
            Session["LastTime"] = DateTime.Today.Date;

            //to limit the axis X data
            double startDate = DateTime.Now.AddDays(-1).Date.ToOADate();
            double endDate = DateTime.Now.AddDays(1).Date.ToOADate();


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
            PA_Versus_ST.Series["RecommendedSteps"]["PixelPointWidth"] = "100";

            //Place Axis titles
            PA_Versus_ST.ChartAreas[0].AxisX.Title = "Date";
            PA_Versus_ST.ChartAreas[0].AxisY.Title = "Screen Time (Hours), Physical Activity (Steps)";



            Label2.Text = "Last updated: Screen time: " + lastTimeST.ToString() + ". Physical activity: " + lastTimePA.ToString();

        }

    }
}