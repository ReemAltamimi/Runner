using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    string userId;
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

        userId = Session["UserId"].ToString();
        Session["DateTime"] = DateTime.Now;
        steps = Convert.ToInt32(Session["Steps"]);
        // TODO: get unlocked levels from DB
        var sessionLevels = HttpContext.Current.Session["unlockedLevels"];
        if (sessionLevels != null)
        {
            unlockedLevels = (int)sessionLevels;
        }
        else
        {
            unlockedLevels = 1;
            HttpContext.Current.Session["unlockedLevels"] = unlockedLevels;
        }
        // TODO: get time remaining from DB
        var sessionTime = HttpContext.Current.Session["timeRemaining"];
        if (sessionTime != null)
        {
            timeRemaining = (int)timeRemaining;
        }
        else
        {  
            timeRemaining = 4800;
            HttpContext.Current.Session["timeRemaining"] = timeRemaining;
        }

        // TODO: get unlocked hearts from DB
        var sessionUnlockedHearts = HttpContext.Current.Session["unlockedHearts"];
        if (sessionUnlockedHearts != null)
        {
            unlockedHearts = sessionUnlockedHearts as List<int>;
        }
        else
        {
            // TODO: get unlocked hearts from DB
            unlockedHearts = new List<int>(new int[] { 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            HttpContext.Current.Session["unlockedHearts"] = unlockedHearts;
        }
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
        
        return "Fast";
    }



    [WebMethod(EnableSession = true)]
    public static void CompleteLevel(int level, int stars, int hearts)
    {
        string userId = (string)(HttpContext.Current.Session["UserId"]);
        // TODO: write unlocked level to db (possibly via User object or database interface class) here
        // TODO: write stars count to db
        // TODO: write hearts count to db
       
        var sessionObj = HttpContext.Current.Session["unlockedLevels"];
       if (sessionObj != null)
        {
            List<int> heartList = sessionObj as List<int>;
            while (heartList.Count < level - 1)
            {
                heartList.Add(0);
            }
            heartList[level - 1] = hearts;
        }
        
    }


    [WebMethod(EnableSession = true)]
    public static void DoHeartbeat(float time)
    {
        string userId = (string)(HttpContext.Current.Session["UserId"]);
        // TODO: write time remaining to db (possibly via User object or database interface class) here
        HttpContext.Current.Session["timeRemaining"] = time;
        
    }
  
}