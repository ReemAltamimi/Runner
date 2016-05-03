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

namespace MySteps
{
    public partial class PhysicalActivityManagement : System.Web.UI.Page
    {

        protected XmlDocument Doc { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string token, refreshToken;
            String userId = Session["UserId"].ToString();
            Session["DateTime"] = DateTime.Now;

            const string FitbitClientId = "227L5Z";
            //"local-fitbit-example-client-application";
            //"aca55fdfdb7d48f3a0c3f5c6505e5567"
            const string FitbitSecret = "26fed8d066abe1bb28e98260f7d4578c";
            //"your.secret.key.from.dev.fitbit.com";
            //"8e97224b8df64178a2970559604fafeb"

            // API call path to get temporary credentials (request token and secret)
            Uri fitBitRequestTokenUrl = new Uri("https://api.fitbit.com/oauth2/token");

            // Base path of URL where the user will authorize this application
            Uri authorizationUri = new Uri("https://www.fitbit.com/oauth2/authorize");

            // API call path to protected resource
            DateTime dt = DateTime.Now;
            string sDay = Convert.ToString(dt.Day);
            string sMonth = Convert.ToString(dt.Month);
            string sYear = Convert.ToString(dt.Year);
            //ToShortDateString();

            string strFitBit = "http://api.fitbit.com/1/user/-/activities/date/" + sYear + "-" + sMonth + "-" + sDay + ".xml";

            string ApiCallUrl = strFitBit;


            /*const string ApiCallUrl = "http://api.fitbit.com/1/user/-/activities/date/2014-05-17.xml";*/

            //// Create OAuthService object, containing oauth consumer configuration
            //OAuthService service = OAuthService.Create(
            //    new EndPoint(RequestTokenUrl, "POST"),         // requestTokenEndPoint
            //    new Uri(AuthorizationUrl),                     // authorizationUri
            //    new EndPoint(AccessTokenUrl, "POST"),          // accessTokenEndPoint
            //    true,                                          // useAuthorizationHeader
            //    "http://api.fitbit.com",                       // realm
            //    "HMAC-SHA1",                                   // signatureMethod
            //    "2.0",                                         // oauthVersion
            //    new OAuthConsumer(FitbitClientId, ConsumerSecret) // consumer
            //    );

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
                //var authorizationState = client.ProcessUserAuthorization();
                //if (authorizationState != null)
                //{
                //    var userAuthorization = client.PrepareRequestUserAuthorization(new[] { "activity" });
                //    userAuthorization.Send(Context);
                //    Response.End();
                //}

                //=============================================================================

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
                /*DataRow[] customerRow = 
                dataSet1.Tables["Customers"].Select("CustomerID = 'ALFKI'");

                customerRow[0]["CompanyName"] = "Updated Company Name";
                customerRow[0]["City"] = "Seattle";*/



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