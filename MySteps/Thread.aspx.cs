using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Thread : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnComment_Click(object sender, EventArgs e)
    {
        string t = Session["forumId"].ToString();

        string forumId = t.ToString();
        int cforumId = Convert.ToInt32(forumId);
        string comment = txbComment.Text;
        string name = txbName.Text;
        DateTime date = DateTime.Now;

        PostThread.insertThread(cforumId, comment, name, date);
        GridView1.DataBind();
        txbComment.Text = "";
               

    }
}