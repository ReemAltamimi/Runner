using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#FFFF80");

    }

    protected void btnChart_Click(object sender, EventArgs e)
    {
       
        try
        {
            //Open the About pdf file
            Response.Redirect("~/About_Chart.pdf");
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }

    }
    protected void btnManul_Click(object sender, EventArgs e)
    {
        try
        {
            //Open the Manual pdf file
            Response.Redirect("~/manual_charge_en_US.pdf");
        }
        catch (Exception exp)
        {
            Console.WriteLine("{0} Exception caught.", exp);
        }

    }
}