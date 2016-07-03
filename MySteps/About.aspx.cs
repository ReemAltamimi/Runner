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
        string FilePath = Server.MapPath("About_Chart.pdf");

        WebClient User = new WebClient();

        Byte[] FileBuffer = User.DownloadData(FilePath);

        if (FileBuffer != null)

        {

            Response.ContentType = "application/pdf";

            Response.AddHeader("content-length", FileBuffer.Length.ToString());

            Response.BinaryWrite(FileBuffer);

        }

    }
    protected void btnManul_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("manual_charge_en_US.pdf");

        WebClient User = new WebClient();

        Byte[] FileBuffer = User.DownloadData(FilePath);

        if (FileBuffer != null)

        {

            Response.ContentType = "application/pdf";

            Response.AddHeader("content-length", FileBuffer.Length.ToString());

            Response.BinaryWrite(FileBuffer);

        }

    }
}