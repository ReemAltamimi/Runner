using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        string titleId = DropDownList1.Text;
        int ctitleId = Convert.ToInt32(titleId);
        string question = txbQuestion.Text;
        string posterName = txbName.Text;
        DateTime dateTime = DateTime.Now;
        PostForum.insertForum(ctitleId, question, posterName, dateTime);
        GridView1.DataBind();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 ForumId = (Int64)GridView1.SelectedValue;
        Session["forumId"] = ForumId;
        Response.Redirect("Thread.aspx");

    }
}