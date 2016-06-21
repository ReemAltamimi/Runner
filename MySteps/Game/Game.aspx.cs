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





            //show pop up window to inform the users that they need to sync their steps 
            //and redirect them to Physical Activity page
            string message = "You need to sync your steps first";
            string url = "/PhysicalActivityManagement.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
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
  
}