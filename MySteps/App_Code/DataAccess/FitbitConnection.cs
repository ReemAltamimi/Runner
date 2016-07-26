using DotNetOpenAuth.OAuth2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for FitbitConnection
/// </summary>
public class FitbitConnection
{

    const string FitbitClientId = "227L5Z";

    //"your.secret.key.from.dev.fitbit.com";
    //"26fed8d066abe1bb28e98260f7d4578c"
    const string FitbitSecret = "26fed8d066abe1bb28e98260f7d4578c";
    
    static AuthorizationServerDescription authorizationServer = new AuthorizationServerDescription
    {
        AuthorizationEndpoint = new Uri("https://www.fitbit.com/oauth2/authorize"),
        TokenEndpoint = new Uri("https://api.fitbit.com/oauth2/token")

    };

    
    static WebServerClient client = new WebServerClient(authorizationServer, FitbitClientId, FitbitSecret);

    private int userId;
    private string token = null;
    private string refreshtoken = null;
    public FitbitConnection()
    {


        //
        // TODO: Add constructor logic here
        //
    }


    public void Connect(int userId, HttpContext context)
    {
        //variables declaration
        if (UserData.getTokens(userId, out token, out refreshtoken))
        {
            // try to use the token 
            try
            {
                string activityUrl = baseActivityUrl + "-/activities/steps/date/"+DateTime.Today.ToString("yyyy-MM-dd") +"/1d.json";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(activityUrl);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + token;
                request.Accept = "application/json";
                WebResponse response = request.GetResponse();
            }
            catch (System.Net.WebException)
            {
                RefreshToken();
            }
        }



        if (String.IsNullOrEmpty(token))
        {
            string refreshToken = null;
            this.userId = userId;
            var authorizationState = client.ProcessUserAuthorization();
            if (authorizationState == null)
            {
                var userAuthorization = client.PrepareRequestUserAuthorization(new[] { "activity" });
                userAuthorization.Send(context);
            }
            else
            {
                token = authorizationState.AccessToken.ToString();
                refreshToken = authorizationState.RefreshToken.ToString();
                //add token and refresh token into UserData table
                UserData.insertTokens(Convert.ToInt32(userId), token, refreshToken);
            }
        }
        
    }


    public void RefreshToken()
    {
        try
        {
            string refreshAuth = FitbitClientId + ":" + FitbitSecret;
            var authBytes = Encoding.UTF8.GetBytes(refreshAuth);
            UriBuilder uri = new UriBuilder(authorizationServer.TokenEndpoint);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.Uri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);
            request.Accept = "application/x-www-form-urlencoded";
            string postData = "grant_type=refresh_token&refresh_token=" + refreshtoken;
            byte[] bodyBytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bodyBytes.Length;
            var stream = request.GetRequestStream();
            stream.Write(bodyBytes, 0, bodyBytes.Length);
            stream.Flush();
            stream.Close();

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            String values = reader.ReadToEnd();

            var obj = JsonConvert.DeserializeObject<RefreshTokenResponse>(values);
            UserData.insertTokens(userId, obj.access_token, obj.refresh_token);
            token = obj.access_token;
            refreshtoken = obj.refresh_token;
        }
        catch (System.Net.WebException)
        {
            UserData.insertTokens(userId, "", "");
            token = null;
            refreshtoken = null;
        }
    }


    class RefreshTokenResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
    }

    public void RevokeToken()
    {
        UriBuilder builder = new UriBuilder("https://api.fitbit.com/oauth2/revoke");
        builder.Query = "token="+token;
        
        string refreshAuth = FitbitClientId + ":" + FitbitSecret;
        var authBytes = Encoding.UTF8.GetBytes(refreshAuth);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(builder.Uri);
        request.Method = "POST";
        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);
        string postData = "token=\"" + token + "\"";
        request.Accept = "application/json";
        byte[] bodyBytes = Encoding.UTF8.GetBytes(postData);
        request.ContentLength = bodyBytes.Length;
        var stream = request.GetRequestStream();
        stream.Write(bodyBytes, 0, bodyBytes.Length);
        stream.Flush();
        stream.Close();
        WebResponse response = request.GetResponse();
    }

    public enum Activity
    {
        steps,
        distance,
        minutesSedentary,
        minutesLightlyActive,
        minutesFairlyActive,
        minutesVeryActive
    };
    public const string baseActivityUrl = "https://api.fitbit.com/1/user/";

    struct ActivityByDateResponse
    {
        public DateTime date { get; set; }
        public float value { get; set; }
    }

    public float GetActivityByDate(Activity activity, DateTime date)
    {
        float retVal = 0;
        string activityDate = date.ToString("yyyy-MM-dd");
        string activityStr = activity.ToString();
        string activityUrl = baseActivityUrl + "-/activities/" + activityStr + "/date/" + activityDate + "/1d.json";
        
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(activityUrl);
        request.Method = "GET";
        request.Headers["Authorization"] = "Bearer " + token;
        request.Accept = "application/json";
        WebResponse response = request.GetResponse();
        StreamReader httpwebStreamReader = new StreamReader(response.GetResponseStream());
        string responseStr = httpwebStreamReader.ReadToEnd();
        response.Close();
        httpwebStreamReader.Close();
        var jsonObj = JObject.Parse(responseStr);
        var activityResp = jsonObj["activities-" + activityStr];
        var value = activityResp[0]["value"].ToString();
        float.TryParse(value, out retVal);

        return retVal;
    }

    
}