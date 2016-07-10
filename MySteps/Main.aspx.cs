using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    FitbitConnection connection = new FitbitConnection();
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["New"] == null)
            Response.Redirect("~/LoginPage.aspx");


        userId = (int)Session["UserId"];

        try
        {
            connection.Connect(userId, Context);

            if (Session["Steps"] == null)
            {
                //Get the date of today
                var activityDate = DateTime.Now;

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
                Session["Distance"] = distance;
                Session["MinSed"] = minSed;
                Session["MinLActive"] = minLActive;
                Session["MinFActive"] = minFActive;
                Session["MinVActive"] = minVActive;
            }
        }
        catch(Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }
    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        Session["New"] = null;
        Session["Steps"] = null;
        Response.Redirect("~/Default.aspx");
    }
    protected void btnScreenTime_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ScreenTimeManagement.aspx");
    }
    protected void btnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserHistory.aspx");
    }
    protected void btnPhysicalActivity_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PhysicalActivityManagement.aspx");
    }
    protected void btnPaVsSt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PA_Vs_ST.aspx");
    }

    protected void btnGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Game/Game.aspx");
    }

    protected void btnLeaderboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Leaderboard.aspx");
    }

    protected void btnChatRoom_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChatRoom.aspx");
    }

    protected void btnForum_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Forum.aspx");
    }
}