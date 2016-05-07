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
            string token, refreshToken, id;

            //check the user id
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
            DateTime dt = DateTime.Now;
            string sDay = Convert.ToString(dt.Day);
            string sMonth = Convert.ToString(dt.Month);
            string sYear = Convert.ToString(dt.Year);
            

            string strFitBit = "http://api.fitbit.com/1/user/-/activities/date/" + sYear + "-" + sMonth + "-" + sDay + ".xml";

            string ApiCallUrl = strFitBit;


            

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
                    //id = userAuthorization.Body.ToString();

                }
                else
                {
                    Session["access_token"] = authorizationState.AccessToken;
                    Session["refresh_token"] = authorizationState.RefreshToken;
                   // id = userAuthorization.Body.ToString();
                }

                token = authorizationState.AccessToken.ToString();
                refreshToken = authorizationState.RefreshToken.ToString();
                //id =;
                //var authorizationState = client.ProcessUserAuthorization();
                //if (authorizationState != null)
                //{
                //    var userAuthorization = client.PrepareRequestUserAuthorization(new[] { "activity" });
                //    userAuthorization.Send(Context);
                //    Response.End();
                //}

                //============================================================================



                if (!IsPostBack)
                {
                    try
                    {
                        //add user data entered in registeration page into UserData table
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
                        conn.Open();
                        string insertQuery = "UPDATE UserData SET Token = @token, RefreshToken = @refreshToken WHERE(Id = @userId)";
                        SqlCommand command = new SqlCommand(insertQuery, conn);
                        command.Parameters.AddWithValue("@token", token);
                        command.Parameters.AddWithValue("@refreshToken", refreshToken);
                        command.Parameters.AddWithValue("@userId", Convert.ToInt32(userId));

                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = "Error :" + ex.ToString();
                    }
                }
                



                ////get the distance value from the xml document
                //distanceAsString = this.Doc["result"]["summary"]["distances"].FirstChild.InnerText; //this will retrieve"total+distanceAsNumber"
                //distanceAsNumber = Regex.Match(distanceAsString, @"\d+(\.\d+)").Value.Replace(" ", ""); //this will extract the distanceAsNumber only
                //if (!double.TryParse(distanceAsNumber, out distance))
                //    distance = 0.0;

                ////Insert data to database
                ////add Physical activity data into PhysicalActivityData table
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
                //conn.Open();
                //string insertQuery = "insert into PhysicalActivityData (UserID,DateAndTime,DailySteps,DistanceWalkedMile,EstimatedActiveTime) values (@id, @dateTime, @steps, @distance, @activetime)";
                //SqlCommand command = new SqlCommand(insertQuery, conn);


                //command.Parameters.AddWithValue("@id", Convert.ToInt32(userId));
                //command.Parameters.AddWithValue("@dateTime", Session["DateTime"]);
                //command.Parameters.AddWithValue("@steps", Convert.ToInt32(this.Doc["result"]["summary"]["steps"].InnerText));
                //command.Parameters.AddWithValue("@distance", distance);
                //command.Parameters.AddWithValue("@activetime", Convert.ToInt32(this.Doc["result"]["summary"]["veryActiveMinutes"].InnerText));

                //command.ExecuteNonQuery();

                //conn.Close();

            }
            catch (WebException ex)
            {
                Response.Write(ex.Message);
                Response.Close();
            }


            //===============================================================================
            //Request the user workout.
            String activityDate = DateTime.Now.ToString("yyyy-MM-dd");

            string urlworkout = "https://api.fitbit.com/1/user/" + "-" + "/activities/steps/date/" + activityDate + "/1d.json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlworkout);
            request.Method = "GET";
            request.Headers["Authorization"] = "Bearer " + Session["access_token"];
            request.Accept = "application/json";

            WebResponse myResponse;
            string results = "";
          

            myResponse = request.GetResponse();
            StreamReader httpwebStreamReader = new StreamReader(myResponse.GetResponseStream());
            results = httpwebStreamReader.ReadToEnd();



            // Initialize the XmlDocument object and OAuthResponse object's protected resource to it
            // this.Doc = new XmlDocument();
            //this.Doc.Load(httpwebStreamReader);
            Label2.Text = results;
            myResponse.Close();
            httpwebStreamReader.Close();

            //===============================================================================

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