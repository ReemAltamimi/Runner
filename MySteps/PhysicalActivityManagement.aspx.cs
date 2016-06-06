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

        protected XmlDocument Doc { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //variables declaration
            string token, refreshToken;

            //check if the user is login in the system
            if (Session["UserId"] == null)
                {
                   Response.Redirect("Default");
                              return;
            }

            String userId = Session["UserId"].ToString();
            Session["DateTime"] = DateTime.Now;

            //"local-fitbit-example-client-application-id";
            //"227L5Z"
            const string FitbitClientId = "227L5Z";

            //"your.secret.key.from.dev.fitbit.com";
            //"26fed8d066abe1bb28e98260f7d4578c"
            const string FitbitSecret = "26fed8d066abe1bb28e98260f7d4578c";
            
            // API call path to get temporary credentials (request token)
            Uri fitBitRequestTokenUrl = new Uri("https://api.fitbit.com/oauth2/token");

            // Base path of URL where the user will authorize this application
            Uri authorizationUri = new Uri("https://www.fitbit.com/oauth2/authorize");

            // API call path to protected resource
            //DateTime dt = DateTime.Now;
            //string sDay = Convert.ToString(dt.Day);
            //string sMonth = Convert.ToString(dt.Month);
            //string sYear = Convert.ToString(dt.Year);
            

            //string strFitBit = "http://api.fitbit.com/1/user/-/activities/date/" + sYear + "-" + sMonth + "-" + sDay + ".xml";

            //string ApiCallUrl = strFitBit;


            

            var authorizationServer = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = authorizationUri,
                TokenEndpoint = fitBitRequestTokenUrl

            };

            try
            {
                WebServerClient client = new WebServerClient(authorizationServer, FitbitClientId, FitbitSecret);

                var authorizationState = client.ProcessUserAuthorization();
                if (authorizationState == null)
                {
                    var userAuthorization = client.PrepareRequestUserAuthorization(new[] { "activity" });
                    userAuthorization.Send(Context);
                }
                else
                {
                    Session["access_token"] = authorizationState.AccessToken;
                    Session["refresh_token"] = authorizationState.RefreshToken;
                }

                token = authorizationState.AccessToken.ToString();
                refreshToken = authorizationState.RefreshToken.ToString();
    
                if (!IsPostBack)
                {
                    /*try
                    {
                        //add token and refresh token into UserData table
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
                        conn.Open();
                        string insertQuery = "UPDATE UserData SET Token = @token, RefreshToken = @refreshToken WHERE(Id = @userId)";
                        SqlCommand command = new SqlCommand(insertQuery, conn);
                        command.Parameters.AddWithValue("@token", token);
                        command.Parameters.AddWithValue("@refreshToken", refreshToken);
                        command.Parameters.AddWithValue("@userId", Convert.ToInt32(userId));

                        command.ExecuteNonQuery();
                        conn.Close();
                    }*/
                    try
                    {
                        //add token and refresh token into UserData table
                        UserData.insertTokens(Convert.ToInt32(userId), token, refreshToken);
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = "Error :" + ex.ToString();
                    }
                }
            }
            catch (WebException ex)
            {
                Response.Write(ex.Message);
                Response.Close();
            }



            //Request the user workout.

            //Get the date of today in a "yyyy-MM-dd" format
            String activityDate = DateTime.Now.ToString("yyyy-MM-dd");

            //create string of 2D array to hold the http requests and responses.
            string[,] workouts = new string[6, 2]{
                { "https://api.fitbit.com/1/user/" + "-" + "/activities/steps/date/" + activityDate + "/1d.json", "" },
                { "https://api.fitbit.com/1/user/" + "-" + "/activities/distance/date/" + activityDate + "/1d.json", "" },
                {"https://api.fitbit.com/1/user/" + "-" + "/activities/minutesSedentary/date/" + activityDate + "/1d.json", "" },
                {"https://api.fitbit.com/1/user/" + "-" + "/activities/minutesLightlyActive/date/" + activityDate + "/1d.json", ""},
                {"https://api.fitbit.com/1/user/" + "-" + "/activities/minutesFairlyActive/date/" + activityDate + "/1d.json", ""},
                {"https://api.fitbit.com/1/user/" + "-" + "/activities/minutesVeryActive/date/" + activityDate + "/1d.json", ""}
            };

            WebResponse myResponse;
            int steps, minSed, minLActive, minFActive, minVActive;
            Double distance;

            //fill the array with responses
            for (int row = 0; row < workouts.GetLength(0); row++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(workouts[row, 0]);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + Session["access_token"];
                request.Accept = "application/json";
                myResponse = request.GetResponse();
                StreamReader httpwebStreamReader = new StreamReader(myResponse.GetResponseStream());
                workouts[row, 1] = httpwebStreamReader.ReadToEnd();
                myResponse.Close();
                httpwebStreamReader.Close();
            }

            

            // Assign the workouts to their values
            steps = Convert.ToInt32(getNumberFromString(workouts[0, 1]));
            distance = Convert.ToDouble(getNumberFromString(workouts[1, 1]));
            minSed = Convert.ToInt32(getNumberFromString(workouts[2, 1]));
            minLActive = Convert.ToInt32(getNumberFromString(workouts[3, 1]));
            minFActive = Convert.ToInt32(getNumberFromString(workouts[4, 1]));
            minVActive = Convert.ToInt32(getNumberFromString(workouts[5, 1]));

            //assign number of steps to session
            Session["Steps"] = steps;


            // Insert data to database
            //add Physical activity data into PhysicalActivityData table
            //Check if the user has already insert his/her data for today
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
            conn1.Open();

            string checkUserId = "select count(*) from PhysicalActivityData where UserID= '" + userId + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command1 = new SqlCommand(checkUserId, conn1);
            int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            if (temp == 1)
            {
                    string updateQuery = "UPDATE PhysicalActivityData SET DateAndTime = @dateTime, DailySteps = @steps, DistanceWalkedMile = @distance, SedentaryMinutes = @sedMin, LightActiveMinutes = @lightMin, FairlyActiveMinutes = @fairlyMin, VeryActiveMinutes = @veryMin  WHERE UserID = '" + userId + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

                    SqlCommand command3 = new SqlCommand(updateQuery, conn1);

                    command3.Parameters.AddWithValue("@dateTime", Session["DateTime"]);
                    command3.Parameters.AddWithValue("@steps", steps);
                    command3.Parameters.AddWithValue("@distance", distance);
                    command3.Parameters.AddWithValue("@sedMin", minSed);
                    command3.Parameters.AddWithValue("@lightMin", minLActive);
                    command3.Parameters.AddWithValue("@fairlyMin", minFActive);
                    command3.Parameters.AddWithValue("@veryMin", minVActive);
                    command3.ExecuteNonQuery();
             }
             else
             {
                    string insertQuery1 = "insert into PhysicalActivityData (UserID,DateAndTime,DailySteps,DistanceWalkedMile,SedentaryMinutes,LightActiveMinutes,FairlyActiveMinutes,VeryActiveMinutes) values (@id, @dateTime, @steps, @distance, @sedMin, @lightMin, @fairlyMin, @veryMin)";
                    SqlCommand command4 = new SqlCommand(insertQuery1, conn1);


                    command4.Parameters.AddWithValue("@id", Convert.ToInt32(userId));
                    command4.Parameters.AddWithValue("@dateTime", Session["DateTime"]);
                    command4.Parameters.AddWithValue("@steps", steps);
                    command4.Parameters.AddWithValue("@distance", distance);
                    command4.Parameters.AddWithValue("@sedMin", minSed);
                    command4.Parameters.AddWithValue("@lightMin", minLActive);
                    command4.Parameters.AddWithValue("@fairlyMin", minFActive);
                    command4.Parameters.AddWithValue("@veryMin", minVActive);

                    command4.ExecuteNonQuery();
                }

                conn1.Close();

            //print the fitbit results on screen
            Label2.Text = "<br />";
            Label2.Text += "Number of Steps = " + steps + "<br />";
            Label2.Text += "The distance you have walked = " + distance + "<br />";
            Label2.Text += "Sedentary time in minutes = " + minSed + "<br />";
            Label2.Text += "Lightly Active Minutes= " + minLActive + "<br />";
            Label2.Text += "Fairly Active Minutes = " + minFActive + "<br />";
            Label2.Text += "Very Active Minutes = " + minVActive + "<br />";

        }
        
        //This Function extraxt the value numbers from a string
        //This function is used to extract the workout values from fitbit responses
        private string getNumberFromString(string str)
        {
            string strNumber;
            
            str = Regex.Replace(str, @"\d{4}-\d{2}-\d{2}",String.Empty);
            strNumber = Regex.Match(str, @"\d+").Value;
            return strNumber;
        }



        protected void btnViewChart_Click(object sender, EventArgs e)
        {
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
            PhysicalActivityChart.Series["RecommendedStepsBoys"]["PixelPointWidth"] = "100";
            PhysicalActivityChart.Series["RecommendedStepsGirls"]["PixelPointWidth"] = "100";

            //show the chart
            PhysicalActivityChart.Visible = true;

            Label3.Text = "Last updated of Physical Activity" + Session["DateTime"].ToString();

        }
    }
}