﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DevGame : System.Web.UI.Page
{
    

    public String GetMovement(){
        int steps = Convert.ToInt32(Session["Steps"]);
        if (steps >= 15000)
        {
            return "Fast";
        }
        if (steps >= 10000)
        {
            return "Medium";
        }
        
        return "Slow";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}