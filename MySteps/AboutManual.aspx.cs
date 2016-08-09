using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class AboutManual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //make image in right and left sides invisible
        ((Image)this.Page.Master.FindControl("Image1")).Visible = false;
        ((Image)this.Page.Master.FindControl("Image2")).Visible = false;
        //make the middle div content invisible
        ((HtmlGenericControl)this.Page.Master.FindControl("content")).Style.Add("visibility", "hidden");

        ((HtmlGenericControl)this.Page.Master.FindControl("rightSidePanel")).Style.Add("visibility", "hidden");

        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#FFFF80");
    }
}