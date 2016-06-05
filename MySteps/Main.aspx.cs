using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["New"] == null)
            Response.Redirect("~/LoginPage.aspx");

    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        //Session["New"] = null;
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
        Response.Redirect("~/Game/Game.aspx");
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