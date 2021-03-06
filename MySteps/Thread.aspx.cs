﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Thread : System.Web.UI.Page
{
    string userId, username;

    protected void Page_Load(object sender, EventArgs e)
    {

        //check if the user is login in the system
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }

        userId = Session["UserId"].ToString();
        username = Session["New"].ToString();
        txbName.Text = username;

        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#ff3377");

        //make image in right and left sides invisible
        ((Image)this.Page.Master.FindControl("Image1")).Visible = false;
        ((Image)this.Page.Master.FindControl("Image2")).Visible = false;
        //make the middle div content invisible
        ((HtmlGenericControl)this.Page.Master.FindControl("content")).Style.Add("visibility", "hidden");

        ((HtmlGenericControl)this.Page.Master.FindControl("rightSidePanel")).Style.Add("visibility", "hidden");

        Label3.Text = "The answer for ' " + PostForum.getQuestion(Convert.ToInt32(Session["ForumId"])) + " ' is : ";

    }

    protected void btnComment_Click(object sender, EventArgs e)
    {
        string t = Session["forumId"].ToString();

        string forumId = t.ToString();
        int cforumId = Convert.ToInt32(forumId);
        string comment = txbComment.Text;
        string name = txbName.Text;
        DateTime date = DateTime.Now;

        try
        {
            PostThread.insertThread(cforumId, comment, name, date);
            GridView1.DataBind();
            txbComment.Text = "";
        }
        catch (Exception exp)
        {
            Response.Output.Write("{0} Exception caught.", exp);
        }


    }
}