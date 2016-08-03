using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;


public partial class Leaderboard2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#80FF80");

        //check if the user is login in the system
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }


        string gamerId = Request.QueryString["gamerId"];
        string gamerName = Request.QueryString["gamerName"];
        lblName.Text = "The game levels details for " + gamerName;

        String query = "select Level, Max(Stars) as Stars, Max(Hearts) as Hearts from UserLevels where UserId = '"+ gamerId + "' Group by UserId, Level";
        GetTableData(query);

    }


    public void GetTableData(string query)
    {
        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader dr;

            dr = cmd.ExecuteReader();

            GridView1.DataSource = dr;

            GridView1.DataBind();

            connection.Close();
        }
    }
}