using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Registeration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            //check if the user is already exists, it will worn the user
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
            conn.Open();
            string checkUser = "select count(*) from UserData where UserName= '"+txbUserName.Text+"'";
            SqlCommand command = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Label2.Text="User already exists";
            }
            conn.Close();
        }

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            //add user data entered in registeration page into UserData table
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
            conn.Open();
            string insertQuery = "insert into UserData (UserName,Email,Password) values (@Uname, @email, @password)";
            SqlCommand command = new SqlCommand(insertQuery, conn);
            command.Parameters.AddWithValue("@Uname",txbUserName.Text);
            command.Parameters.AddWithValue("@email",txbEmail.Text);
            command.Parameters.AddWithValue("@password",txbPassword.Text);

            command.ExecuteNonQuery();

            txbUserName.Text = "";
            txbEmail.Text = "";
            Label2.Text = "Registeration is successfully completed";

            conn.Close();
        }
        catch(Exception ex)
        {
            Label2.Text="Error :"+ex.ToString();
        }
        
    }
}