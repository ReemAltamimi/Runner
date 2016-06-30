#define BEN_IS_LAZY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class Default2 : System.Web.UI.Page
{
    int userId;
    int steps;
    int unlockedLevels;
    float timeRemaining;
    List<int> unlockedHearts = new List<int>();
    List<int> stars = new List<int>();

    FitbitConnection connection = new FitbitConnection();



    public int Steps{
        get { return steps; }
    }


    public int UnlockedLevels {
        get { return unlockedLevels; }
    }


    public String UnlockedHearts {
        get {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            for (int i = 0; i < unlockedHearts.Count; i++)
            {
                builder.Append(unlockedHearts[i]);
                if (i < unlockedHearts.Count - 1)
                {
                    builder.Append(",");
                }
            }
            return builder.ToString();
        }
    }

    public float TimeRemaining {
        get { return timeRemaining; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the user is login in the system
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }
        userId = (int)Session["UserId"];
        Session["DateTime"] = DateTime.Now;

        // make sure that steps is set on login or query fitbit here...

        if (Session["Steps"] == null)
        {
            connection.Connect(userId, Context);
            //Get the date of today
            var activityDate = DateTime.Now;

            var stepsNo = connection.GetActivityByDate(FitbitConnection.Activity.steps, activityDate);
            var distance = connection.GetActivityByDate(FitbitConnection.Activity.distance, activityDate);
            var minSed = connection.GetActivityByDate(FitbitConnection.Activity.minutesSedentary, activityDate);
            var minLActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesLightlyActive, activityDate);
            var minFActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesFairlyActive, activityDate);
            var minVActive = connection.GetActivityByDate(FitbitConnection.Activity.minutesVeryActive, activityDate);
            //add Physical activity data into PhysicalActivityData table
            PhysicalActivity.insertPAData(Convert.ToInt32(userId), DateTime.Now, (int)stepsNo, Convert.ToSingle(distance), (int)minSed, (int)minLActive, (int)minFActive, (int)minVActive);

            Session["Steps"] = stepsNo;
            Response.Write("<script language='javascript'>alert('Your number of steps today is:" + Session["Steps"].ToString() + "')</script>");


        }

        steps = Convert.ToInt32(Session["Steps"]);
#if BEN_IS_LAZY
        steps = 10000;
#endif

        // get unlocked levels from DB
        unlockedLevels = Game.getUnLockedLevel(userId);

        if (!Game.gameDayRecordExists(userId))
        {
            Game.insertGameData(userId, DateTime.Today, unlockedLevels, Game.DEFAULT_TIME);
        }

        // get time remaining from DB
        timeRemaining = Game.getTimeOfPlay(userId, DateTime.Now);
        
        // get unlocked hearts from DB
        unlockedHearts = UserLevels.getHearts(userId);
        
    }


    public String GetMovement()
    {
        // TODO: get number of steps from user object or DB or session
        //int steps = 10000; // Session[Steps]
        if (steps >= 10000)
        {
            return "Fast";
        }
        if (steps >= 5000)
        {
            return "Medium";
        }
        
        return "Slow";
    }



    [WebMethod(EnableSession = true)]
    public static void CompleteLevel(int level, int stars, int hearts)
    {
        int userId = (int)(HttpContext.Current.Session["UserId"]);
        // TODO: write unlocked level to db (possibly via User object or database interface class) here
        // TODO: write stars count to db
        // TODO: write hearts count to db
        UserLevels.insertUserLevel(userId, level, stars, hearts);
        Game.updateUnlockedLevel(userId, DateTime.Now, level + 1);
    }


    [WebMethod(EnableSession = true)]
    public static void DoHeartbeat(float time)
    {

        var userIdObj = HttpContext.Current.Session["UserId"];
        if (userIdObj != null)
        {
            int userId = (int)(HttpContext.Current.Session["UserId"]);
            Game.updateTimeOfPlay(userId, DateTime.Now, time);
        }

    }

    public int getLasUpdatedSteps(int userId)
    {
        int steps = 0;
        steps = PhysicalActivity.getSteps(DateTime.Today.Date, userId);
        return steps;
    }


}