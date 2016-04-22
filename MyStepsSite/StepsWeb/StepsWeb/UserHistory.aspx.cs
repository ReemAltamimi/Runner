using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

public partial class UserHistory : System.Web.UI.Page
{
    string userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //get the user id, the range of 7 previous dates for chart select statements
        userId = Session["UserId"].ToString();
        Session["Date"] = DateTime.Today.ToShortDateString();
        Session["Date2"] = DateTime.Today.AddDays(-7).ToShortDateString();

    }
    protected void btnST_Click(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffff99");
        Label1.Text = "Your Screen Time Statistics in the last few days";
        Label2.Text = "";

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
        conn.Open();
        DateTime lastTime;
        string strSTAmount;
        int ST_Amount=0;
        DateTime currentDate = DateTime.Today.AddDays(-5);
        
        DateTime currentDate2 = DateTime.Today.AddDays(-5).AddHours(23).AddMinutes(59);
        
        string checkLastTime;
        for (int i = 1; i <= 5; i++)
        {
            //select the last time in date column that match the current session user id and a specific date
            checkLastTime = "select Max(Date) from ScreenTimeData where UserID= '"+ userId+"' AND Date between CONVERT(datetime,'"+currentDate+"',103) AND CONVERT(datetime,'"+currentDate2+"',103)";

            SqlCommand command1 = new SqlCommand(checkLastTime, conn);
            
            if ((command1.ExecuteScalar() != DBNull.Value))
            {
                SqlCommand tempCommand = new SqlCommand(checkLastTime, conn);
                lastTime = Convert.ToDateTime(tempCommand.ExecuteScalar());

                //get the screen time amount of the last update
                string checkScreenTime = "select UserScreenDailyAmnt from ScreenTimeData where UserID = '" + userId + "' AND Date > Convert(datetime,'" + lastTime + "',103) AND Date <= DATEADD(s,1, Convert(datetime,'" + lastTime + "',103))";
                SqlCommand command2 = new SqlCommand(checkScreenTime, conn);
                strSTAmount = command2.ExecuteScalar().ToString().Replace(" ","");
                ST_Amount = Convert.ToInt32(strSTAmount);

                //add data to chart
                ScreenTimeChart.Series["UserScreenTime"].Points.AddXY(lastTime.Date,ST_Amount);
                ScreenTimeChart.Series["ScreenTimeLimit"].Points.AddXY(lastTime.Date, 3);
              
            }

            Label2.Text= Label2.Text+"<br/>"+"On "+currentDate.ToShortDateString()+" your screen time amount was "+ ST_Amount+" hours";
            ST_Amount = 0;
            currentDate = currentDate.AddDays(1);
            currentDate2 = currentDate.AddHours(23).AddMinutes(59);
        
        }
        

        conn.Close();

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
    protected void btnPA_Click(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
        Label1.Text = "Your Exercise Performance Statistics in the last few days";
        Label2.Text = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
        conn.Open();
        DateTime lastTime;
        string strDailySteps;
        int dailySteps=0;
        DateTime currentDate = DateTime.Today.AddDays(-5);

        DateTime currentDate2 = DateTime.Today.AddDays(-5).AddHours(23).AddMinutes(59);

        string checkLastTime;
        for (int i = 1; i <= 5; i++)
        {
            //select the last time in date column that match the current session user id and a specific date
            checkLastTime = "select Max(DateAndTime) from PhysicalActivityData where UserID= '" + userId + "' AND DateAndTime between CONVERT(datetime,'" + currentDate + "',103) AND CONVERT(datetime,'" + currentDate2 + "',103)";

            SqlCommand command1 = new SqlCommand(checkLastTime, conn);

            if ((command1.ExecuteScalar() != DBNull.Value))
            {
               // SqlCommand tempCommand = new SqlCommand(checkLastTime, conn);
                //lastTime = Convert.ToDateTime(tempCommand.ExecuteScalar());
                lastTime = Convert.ToDateTime(command1.ExecuteScalar());

                //get the last updated number of steps 
                string checkDailySteps = "select DailySteps from PhysicalActivityData where UserID = '" + userId + "' AND DateAndTime > Convert(datetime,'" + lastTime + "',103) AND DateAndTime <= DATEADD(s,1, Convert(datetime,'" + lastTime + "',103))";
                SqlCommand command2 = new SqlCommand(checkDailySteps, conn);
                strDailySteps = command2.ExecuteScalar().ToString().Replace(" ", "");
                dailySteps = Convert.ToInt32(strDailySteps);

                //add data to chart
                PhysicalActivityChart.Series["UserPhysicalSteps"].Points.AddXY(lastTime.Date, dailySteps);
                PhysicalActivityChart.Series["RecommendedStepsBoys"].Points.AddXY(lastTime.Date, 13000);
                PhysicalActivityChart.Series["RecommendedStepsGirls"].Points.AddXY(lastTime.Date, 11000);
                
            }

            Label2.Text = Label2.Text + "<br/>" + "On " + currentDate.ToShortDateString() + " your steps amount was " + dailySteps + " steps";
            dailySteps = 0;

            currentDate = currentDate.AddDays(1);
            currentDate2 = currentDate.AddHours(23).AddMinutes(59);

        }


        conn.Close();

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
        PhysicalActivityChart.Series["RecommendedStepsBoys"]["PixelPointWidth"] = "25";
        PhysicalActivityChart.Series["RecommendedStepsGirls"]["PixelPointWidth"] = "25";

        //show the chart
        PhysicalActivityChart.Visible = true;

    }
}