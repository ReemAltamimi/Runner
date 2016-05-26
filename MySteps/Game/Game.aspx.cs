using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        unlockedLevels = 4;// get unlocked levels from DB
        timeRemaining = 3600;// get time remaining from DB
    }


    public String GetMovement()
    {
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

    public void DoHeartBeat(float time)
    {
        timeRemaining -= time;
        // remove time remaining from DB
    }
    
}