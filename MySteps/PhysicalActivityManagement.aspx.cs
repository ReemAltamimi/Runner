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

        FitbitConnection connection = new FitbitConnection();

        protected void Page_Load(object sender, EventArgs e)
        { 
            //check if the user is login in the system
            if (Session["UserId"] == null)
            {
                Response.Redirect("Default");
                return;
            }
           
            userId = (int)Session["UserId"];
            Session["DateTime"] = DateTime.Now;
            connection.Connect(userId, Context);
        }
        
      
        protected void btnSync_Click(object sender, EventArgs e)
        {
            //Get the date of today
            var activityDate = DateTime.Now;

            try
            {
                var steps = connection.GetActivityByDate(FitbitConnection.Activity.steps, activityDate);
                var distance = connection.GetActivityByDate(FitbitConnection.Activity.distance, activityDate);
                var minSed = connection.GetActivityByDate(FitbitConnection.Activity.minutesSedentary, activityDate);
                var minLActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesLightlyActive, activityDate);
                var minFActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesFairlyActive, activityDate);
                var minVActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesVeryActive, activityDate);

                //add Physical activity data into PhysicalActivityData table
                PhysicalActivity.insertPAData(Convert.ToInt32(userId), DateTime.Now, (int)steps, Convert.ToSingle(distance), (int)minSed, (int)minLActive, (int)minFActive, (int)minVActive);

                Session["ActivityDate"] = activityDate;
                Session["Steps"] = steps;

                Label4.Visible = true;
                    Label2.Text = "<br />";
                    Label2.Text += "Number of Steps = " + (int)steps + "<br />";
                    Label2.Text += "The distance you have walked = " + Convert.ToSingle(distance) + "<br />";
                    Label2.Text += "Sedentary time in minutes = " + (int)minSed + "<br />";
                    Label2.Text += "Lightly Active Minutes= " + (int)minLActive + "<br />";
                    Label2.Text += "Fairly Active Minutes = " + (int)minFActive + "<br />";
                    Label2.Text += "Very Active Minutes = " + (int)minVActive + "<br />";              
            }
            catch(Exception exp)
            {
                Label2.Text = "Exception caught." + exp;
            }
          

        }

        protected void btnViewChart_Click(object sender, EventArgs e)
        {

            try
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
            catch (Exception exp)
            {
                Label2.Text = "Exception caught." + exp;
            }
       
        }


        protected void resetToken(object sender, EventArgs e)
        {
            //connection.RevokeToken();
        }


        protected void refreshToken(object sender, EventArgs e)
        {
            //connection.RefreshToken();
        }

    }
}