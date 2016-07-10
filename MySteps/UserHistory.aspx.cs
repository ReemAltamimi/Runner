using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;

public partial class UserHistory : System.Web.UI.Page
{
    string userId;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#AD5BFF");

        //check if the user is login in the system

        if (Session["New"] == null)
            Response.Redirect("~/LoginPage.aspx");

        //get the user id, the range of 7 previous dates for chart select statements
        userId = Session["UserId"].ToString();
        Session["Date"] = DateTime.Today.ToShortDateString();
        Session["Date2"] = DateTime.Today.AddDays(-7).ToShortDateString();

    }

    protected void btnST_Click(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffff99");
        Label1.Text = "Your Screen Time Statistics in the last five days";
        Label2.Text = "";

        DateTime date1 = DateTime.Today.Date;
        
        int st = 0;

        try
        {
            for (int i = 1; i <= 5; i++)
            {
                //get the screen time amount of a specific date
                st = ScreenTime.getScreenTime(date1, Convert.ToInt32(userId));

                if (st != 0)
                {
                    //add data to chart
                    ScreenTimeChart.Series["UserScreenTime"].Points.AddXY(date1.Date, st);
                    ScreenTimeChart.Series["ScreenTimeLimit"].Points.AddXY(date1.Date, 3);

                }
                //print amount and date on screen
                Label2.Text = Label2.Text + "On " + date1.ToShortDateString() + " your screen time amount was " + st + " hours" + "<br/>";
                st = 0;
                date1 = date1.AddDays(-1);

            }

            double startDate = DateTime.Today.AddDays(-5).ToOADate();
            double endDate = DateTime.Today.ToOADate();

            //limit the values that appear in x axis 
            ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.Minimum = startDate;
            ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.Maximum = endDate;
            //to show each single day in x axis
            ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //to show the x axis labels vertically
            ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 90;
            //set the width of series column in the char
            ScreenTimeChart.Series["ScreenTimeLimit"]["PixelPointWidth"] = "25";
            ScreenTimeChart.Series["UserScreenTime"]["PixelPointWidth"] = "25";

            //show the chart
            ScreenTimeChart.Visible = true;
        }
        catch (Exception exp)
        {
            Label2.Text = "Exception caught: " + exp;
        }


        
    }

    protected void btnPA_Click(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
        Label1.Text = "Your Steps in the last five days";
        Label2.Text = "";
      

        DateTime date1 = DateTime.Today.Date;
        
        int steps = 0;

        try
        {
            for (int i = 1; i <= 5; i++)
            {
                //get the screen time amount of a specific date
                steps = PhysicalActivity.getSteps(date1, Convert.ToInt32(userId));


                //add data to chart
                PhysicalActivityChart.Series["UserPhysicalSteps"].Points.AddXY(date1.Date, steps);
                PhysicalActivityChart.Series["RecommendedSteps"].Points.AddXY(date1.Date, 10000);

                //print amount and date on screen
                Label2.Text = Label2.Text + "On " + date1.ToShortDateString() + "  your steps amount was  " + steps + " Steps" + "<br/>";
                steps = 0;
                date1 = date1.AddDays(-1);

            }

            double startDate = DateTime.Today.AddDays(-5).ToOADate();
            double endDate = DateTime.Today.ToOADate();

            //limit the values that appear in x axis 
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.Minimum = startDate;
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.Maximum = endDate;
            //to show each single day in x axis
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //to show the x axis labels vertically
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 90;
            //set the width of series column in the char
            PhysicalActivityChart.Series["UserPhysicalSteps"]["PixelPointWidth"] = "25";
            PhysicalActivityChart.Series["RecommendedSteps"]["PixelPointWidth"] = "25";

            //show the chart
            PhysicalActivityChart.Visible = true;

        }
        catch (Exception exp)
        {
            Label2.Text = "Exception caught: " + exp;
        }    
    }
}