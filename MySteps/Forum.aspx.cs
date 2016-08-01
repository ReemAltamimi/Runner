using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class Forum : System.Web.UI.Page
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

    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        string titleId = DropDownList1.Text;
        int ctitleId = Convert.ToInt32(titleId);
        string question = txbQuestion.Text;
        string posterName = txbName.Text;
        DateTime dateTime = DateTime.Now;

        try
        {
            PostForum.insertForum(ctitleId, question, posterName, dateTime);
            GridView1.DataBind();
            txbQuestion.Text = "";
        }
        catch(Exception exp)
        {
            Response.Output.Write("{0} Exception caught.", exp);
        }
       
       

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 ForumId = (Int64)GridView1.SelectedValue;
        Session["forumId"] = ForumId;
        Response.Redirect("Thread.aspx");

    }
}