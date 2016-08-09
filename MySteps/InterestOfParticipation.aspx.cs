using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public partial class InterestOfParticipation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#AD5BFF");


        //make image in right and left sides invisible
        ((Image)this.Page.Master.FindControl("Image1")).Visible = false;
        ((Image)this.Page.Master.FindControl("Image2")).Visible = false;
        //make the middle div content invisible
        ((HtmlGenericControl)this.Page.Master.FindControl("content")).Style.Add("visibility", "hidden");

        ((HtmlGenericControl)this.Page.Master.FindControl("rightSidePanel")).Style.Add("visibility", "hidden");


    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int isRegistered = 0;
        try
        {
            //check if the user is already exists, it will worn the user
            isRegistered = participantRegistration();

            if (isRegistered == 1)
            {
                txbUserName.Text = "";
                txbEmail.Text = "";

                Label2.Text = "Great! Registeration is successfully completed";
            }
            else
            {
                Label2.Text = "Error! Check your details again please ..";
            }
        }
        catch(Exception)
        {
            Label2.Text = "Error! Exception Caught ..";
        }
    }
    public int participantRegistration()
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string insertQuery = "insert into InterestedParticipants (Name,Email,Classification) values (@name, @email, @classification)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.Add("@name", SqlDbType.NChar).Value = txbUserName.Text.Trim();
            command.Parameters.Add("@email", SqlDbType.NChar).Value = txbEmail.Text.Trim();
            command.Parameters.Add("@classification", SqlDbType.NChar).Value = dnlClassification.SelectedItem.Text.Trim();

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

}