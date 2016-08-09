using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Image)this.Page.Master.FindControl("Image1")).Visible = false;
        ((Image)this.Page.Master.FindControl("Image2")).Visible = false;
    }
    
    protected void imgBtnAbout_Click(object sender, ImageClickEventArgs e)
    {
        //navigate to About page
        Response.Redirect("~/About.aspx");
    }
    protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //navigate to Login page
        Response.Redirect("~/LoginPage.aspx");

    }
    protected void imgBtnAddUser_Click(object sender, ImageClickEventArgs e)
    {
        //navigate to Registeration page
        Response.Redirect("~/Registeration.aspx");

    }
    protected void imgBtnHelp_Click(object sender, ImageClickEventArgs e)
    {
        //navigate to Contact page
        Response.Redirect("~/Contact.aspx");
    }
    protected void ImgBtnInfoStamnt_Click(object sender, ImageClickEventArgs e)
    {
        //navigate to About page
        Response.Redirect("~/InfoStatement.aspx");
    }
    protected void ImgBtnParticipationForm_Click(object sender, ImageClickEventArgs e)
    {
        //navigate to About page
        Response.Redirect("~/InterestOfParticipation.aspx");
    }
}