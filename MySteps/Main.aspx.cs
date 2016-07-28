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
              
            }
            //assign Session["YesterdaySteps"] for game play
            if (Session["YesterdaySteps"] == null)
            {
                Session["YesterdaySteps"] = PhysicalActivity.getSteps(DateTime.Now.AddDays(-1).Date, userId);

                int CheckFirstDayAward = UserData.getFisrtDayAward(Convert.ToInt32(userId));

             //In case of zero steps in yesterday
                if (Convert.ToInt32(Session["YesterdaySteps"]) == 0)
                {
                    //In case of first day login
                    if (CheckFirstDayAward == 0)
                    {
                        Session["YesterdaySteps"] = 10000;
                        int rows = UserData.SetFisrtDayAwardToTrue(Convert.ToInt32(userId));
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('Warning: Your number of steps for yesterday is:" + Session["YesterdaySteps"].ToString() + " , so you will be slow at game play')</script>");

                    }

                }

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
        Session["YesterdaySteps"] = null;
        Session["UserId"] = null;
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
        if(Session["GroupName"].ToString().Trim().Equals("Experiment"))
        {
            //Response.Redirect("~/Game/Game.aspx");
            Response.Redirect("~/Game/Game.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
          
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