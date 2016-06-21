using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Steps"] == null)
        {

            //show pop up window to inform the users that they need to sync their steps 
            //and redirect them to Physical Activity page
            string message = "Do You want to sync your steps first";
            string url = "/PhysicalActivityManagement.aspx";
            string script = "window.onload = function(){ var answer=confirm('";
            script += message;
            script += "');";
            script += "if (answer){";
            script += "window.location = '";
            script += url;
            script += "'; }";
            script += "else{";
            script += " alert(\"you responded CANCEL\");"; //here I should call the 'getLasUpdatedSteps' funtion that get the last updated steps number from db
            script += "}}";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }

        /*String jsScript = "";
        jsScript += "var answer=confirm(\'Unable to locate your search item. Do you want to search the closest match from your item?\');\n";
        jsScript += "if (answer){\n";
        jsScript += " document.getElementById('btnSample').click();\n";
        jsScript += "}\n";
        jsScript += "else{//the answer is CANCEL\n";
        jsScript += " alert(\"you responded CANCEL\");\n";
        jsScript += "}\n";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", jsScript, true);*/

        /*string confirmValue = Request.Form["confirm_value"];
         if (confirmValue == "Yes")
         {
             //Your logic for OK button
             Label1.Text = "Yes";
         }
         else
         {
             //Your logic for cancel button
             Label1.Text = "No";
         }*/

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int userid = Convert.ToInt32(Session["UserId"]);
        DateTime d = DateTime.Now.Date;

        //=============================================================
        //test insertgamedata function
        // Game.insertGameData(userid, d, 4, 4);
        //  Label1.Text = "done";

        //test insertgamedata function
        // Game.updateUnlockedLevel(userid, d, 3);

        //test insertgamedata function
        // Game.updateTimeOfPlay(userid, d, 2);


        //test getTimeOfPlay function
        //int level = Game.getUnLockedLevel(16, d);
        //Label1.Text = level.ToString();

        //test getTimeOfPlay function
        float time = Game.getTimeOfPlay(16, DateTime.Now);
        Label1.Text = time.ToString();
        //==================================================================

        //test 
        //UserLevels.insertUserLevel(userid, 1, 20, 0);
        //Label1.Text = "done";

        //UserLevels.updateStars(userid, 1, 50);
        //UserLevels.updateHearts(userid, 1, 1);
        //Label1.Text = "done";

        //int stars = UserLevels.getStars(userid, 1);
        //int hearts = UserLevels.getHearts(userid, 1);

        //Label1.Text = stars.ToString() + hearts.ToString();


    }

    public int getLasUpdatedSteps(int userId)
    {
        int steps = 0;
        steps = PhysicalActivity.getSteps(DateTime.Today.Date, userId);
        return steps;
    }


  
}