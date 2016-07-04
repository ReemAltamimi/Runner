using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using DotNetOpenAuth.OAuth2;
using System.Net.Http;
using System.IO;

namespace MySteps
{
    public partial class PhysicalActivityManagement : System.Web.UI.Page
    {
        int userId;

        protected XmlDocument Doc { get; private set; }
        //FitbitConnection connection = new FitbitConnection();

        protected void Page_Load(object sender, EventArgs e)
        { 
           

            //check if the user is login in the system
            if (Session["UserId"] == null)
            {
                Response.Redirect("Default");
                return;
            }
           
            userId = (int)Session["UserId"];
           // connection.Connect(userId, Context);
            Session["DateTime"] = DateTime.Now;
        }
        
      
        protected void btnSync_Click(object sender, EventArgs e)
        {
           

            //Get the date of today
            var activityDate = DateTime.Now;

            // var steps = connection.GetActivityByDate(FitbitConnection.Activity.steps, activityDate);
            //var distance = connection.GetActivityByDate(FitbitConnection.Activity.distance, activityDate);
            // var minSed = connection.GetActivityByDate(FitbitConnection.Activity.minutesSedentary, activityDate);
            // var minLActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesLightlyActive, activityDate);
            //  var minFActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesFairlyActive, activityDate);
            //  var minVActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesVeryActive, activityDate);

            //print the fitbit results on screen
            // Label2.Text = "<br />";
            // Label2.Text += "Number of Steps = " + steps + "<br />";
            // Label2.Text += "The distance you have walked = " + distance + "<br />";
            // Label2.Text += "Sedentary time in minutes = " + minSed + "<br />";
            // Label2.Text += "Lightly Active Minutes= " + minLActive + "<br />";
            // Label2.Text += "Fairly Active Minutes = " + minFActive + "<br />";
            // Label2.Text += "Very Active Minutes = " + minVActive + "<br />";

            //add Physical activity data into PhysicalActivityData table
            //  PhysicalActivity.insertPAData(Convert.ToInt32(userId), DateTime.Now, (int)steps, Convert.ToSingle(distance), (int)minSed, (int)minLActive, (int)minFActive, (int)minVActive);

            // Session["Steps"] = steps;
            if(Session["Steps"]== null)
            {
                Response.Redirect("~/Main.aspx");
            }
            else
            {
                Label2.Text = "<br />";
                Label2.Text += "Number of Steps = " + Session["Steps"] + "<br />";
                Label2.Text += "The distance you have walked = " + Session["Distance"] + "<br />";
                Label2.Text += "Sedentary time in minutes = " + Session["MinSed"] + "<br />";
                Label2.Text += "Lightly Active Minutes= " + Session["MinLActive"] + "<br />";
                Label2.Text += "Fairly Active Minutes = " + Session["MinFActive"] + "<br />";
                Label2.Text += "Very Active Minutes = " + Session["MinVActive"] + "<br />";

            }

        }



        protected void btnViewChart_Click(object sender, EventArgs e)
        {

            DateTime lastTime = PhysicalActivity.getLastTimeInserted(Convert.ToInt32(userId));

            //set the last time for chart data customization
            Session["LastTime"] = lastTime;

            double startDate = DateTime.Now.AddDays(-1).ToOADate();
            double endDate = DateTime.Now.AddDays(1).ToOADate();

            //limit the values that appear in x axis 
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.Minimum = startDate;
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.Maximum = endDate;
            //to show each single day in x axis
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //to show the x axis labels vertically
            PhysicalActivityChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 90;
            //set the width of series column in the chart
            PhysicalActivityChart.Series["UserPhysicalSteps"]["PixelPointWidth"] = "100";
            PhysicalActivityChart.Series["RecommendedSteps"]["PixelPointWidth"] = "100";

            //show the chart
            PhysicalActivityChart.Visible = true;

            Label3.Text = "Last updated of Physical Activity" + lastTime.ToString();

        }


        protected void resetToken(object sender, EventArgs e)
        {
            //connection.RevokeToken();
        }


        protected void refreshToken(object sender, EventArgs e)
        {
            //connection.RefreshToken();
        }
        //This Function extract the value numbers from a string
        //This function is used to extract the workout values from fitbit responses
        /*private string getNumberFromString(string str)
        {
            string strNumber;

            str = Regex.Replace(str, @"\d{4}-\d{2}-\d{2}", String.Empty);
            strNumber = Regex.Match(str, @"\d+").Value;
            return strNumber;
        }*/

    }
}