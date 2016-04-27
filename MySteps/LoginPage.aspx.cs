using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class LoginPage : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Place the cursor in username textbox
        txbUserName.Focus();       

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
        conn.Open();
        string checkUser = "select count(*) from UserData where UserName= '" + txbUserName.Text + "'";
        SqlCommand command1 = new SqlCommand(checkUser, conn);
        int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
        if (temp == 1)
        {
            string checkPassword = "select Password from UserData where UserName= '" + txbUserName.Text + "'";
            SqlCommand command2 = new SqlCommand(checkPassword, conn);
            string password = command2.ExecuteScalar().ToString().Replace(" ","");
            if (password == txbPassword.Text)
            {
                Session["New"] = txbUserName.Text;
                //get the user id
                string userIdQuery = "select Id from UserData where UserName= '" + Session["New"].ToString() + "' and Password= '" +password.ToString()+"'";
                SqlCommand command3 = new SqlCommand(userIdQuery, conn);
                string userId = command3.ExecuteScalar().ToString();
                Session["UserId"] = userId;
                Response.Redirect("~/Main.aspx");

            }
            else
            {
                Label2.Text = "Error: Password is not correct ..";
                txbUserName.Text = "";
            }
        }
        else
        {
            Label2.Text = "Error: User name is not correct ..";
            txbUserName.Text = "";
        }
        conn.Close();

    }
}