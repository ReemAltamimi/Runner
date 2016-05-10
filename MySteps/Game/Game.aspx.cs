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

        //get the mode of the game
        String mode = GetMovement();
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

    
}