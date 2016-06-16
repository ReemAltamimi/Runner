using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ChatRoom : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#99CCFF");


        //check if the user is login in the system
        if (Session["New"] == null)
            Response.Redirect("~/LoginPage.aspx");
        else
            Session["UserName"] = Session["New"];

        //this.Form.DefaultButton = "sendmessage";

    }

    private void OnKeyDownHandler(object sender, EventArgs e)
    {
      
    }


}