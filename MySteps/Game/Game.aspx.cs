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
    public int Steps{
        get { return steps; }
    }


    public int UnlockedLevels {
        get { return unlockedLevels; }
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
        unlockedLevels = 4;// TODO: get unlocked levels from DB
        timeRemaining = 3600;// TODO: get time remaining from DB
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
    public static void CompleteLevel(int level)
    {
        int userId = (int)(HttpContext.Current.Session["UserId"]);
        // TODO: write unlocked level to db (possibly via User object or database interface class) here
        HttpContext.Current.Session["unlockedLevels"] = level;
    }


    [WebMethod(EnableSession = true)]
    public static void DoHeartbeat(float time)
    {
        float timeRemaining = (float)HttpContext.Current.Session["timeRemaining"];
        timeRemaining -= time;
        // TODO: write time remaining to db (possibly via User object or database interface class) here
        HttpContext.Current.Session["timeRemaining"] = time;
        
    }

  
}