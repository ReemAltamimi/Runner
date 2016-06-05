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
        //int level = Game.getUnLockedLevel(userid, d);
        //Label1.Text = level.ToString();

        //test getTimeOfPlay function
        //float time = Game.getTimeOfPlay(userid, d);
        //Label1.Text = time.ToString();
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
}