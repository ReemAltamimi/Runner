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
    //create a string of band codes for the first group.
    string[] participantsCodes = new string[] { "G1B1", "G1B2", "G1B3", "G1B4", "G1B5",
    "G1B6", "G1B7", "G1B8", "G1B9", "G1B10"};

    bool isParticipant = false;


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int isRegistered = 0;
        try
        {
            //check if the user is already exists, it will worn the user
            isRegistered = UserData.checkUser(txbEmail.Text.Trim());
            
            if (isRegistered == 1)
            {
                txbUserName.Text = "";
                txbEmail.Text = "";
                txbPassword.Text = "";
                txbConfPassword.Text = "";
                txbCodeBand.Text = "";
                Label2.Text = "Error: User already exists, please Enter details of a new user";
            }
            else
            {
                //check if the user is one of the experiment participants (Not allow the public to register)
                //Check if the band code is correct.
                isParticipant = checkParticipants(txbCodeBand.Text.Trim());
                if (isParticipant)
                {
                    //Check if this band code has not used before (Allow one user with one band)
                    int usedBand = UserData.checkBandCode(txbCodeBand.Text.Trim());
                    
                    if (usedBand == 1)
                    {
                        txbUserName.Text = "";
                        txbEmail.Text = "";
                        txbPassword.Text = "";
                        txbConfPassword.Text = "";
                        txbCodeBand.Text = "";
                        Label2.Text = "Error: Your band code has already been used, check your band code";
                    }

                    //The user has not registered before
                    //The user is one of the participants
                    //The user has his/her band code which has not used before.
                    else
                    {
                        //add user data entered in registeration page into UserData table
                        int inserted = UserData.insertUserData(txbUserName.Text.Trim(), txbEmail.Text.Trim(), txbPassword.Text.Trim(), txbCodeBand.Text.Trim());
                        if (inserted == 1)
                        {
                            txbUserName.Text = "";
                            txbEmail.Text = "";
                            txbPassword.Text = "";
                            txbConfPassword.Text = "";
                            txbCodeBand.Text = "";
                            Label2.Text = "Great! Registeration is successfully completed";
                        }

                        
                    }

                }
                //The band code is not correct and the user is not one of the participants
                else
                {
                    txbUserName.Text = "";
                    txbEmail.Text = "";
                    txbPassword.Text = "";
                    txbConfPassword.Text = "";
                    txbCodeBand.Text = "";
                    Label2.Text = "Error: You are not one of the participants, check your band code";

                }
            }
        }
        catch (Exception ex)
        {
            Label2.Text = "Error :" + ex.ToString();
        }


        //==================================================================
        /*try
        {
            //check if the user is already exists, it will worn the user
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
            conn.Open();

            //check if the user is already exists, it will worn the user
            string checkUser = "select count(*) from UserData where Email= '" + txbEmail.Text + "'";
            SqlCommand command = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            if (temp == 1)
            {
                txbUserName.Text = "";
                txbEmail.Text = "";
                txbCodeBand.Text = "";
                Label2.Text = "User already exists";
            }
            else
            {
                //check if the user is one of the experiment participants (Not allow the public to register)
                //Check if the band code is correct.
                isParticipant = checkParticipants(txbCodeBand.Text.Trim());
                if(isParticipant)
                {
                    //Check if this band code has not used before (Allow one user with one band)
                    string checkBandCode = "select count(*) from UserData where BandCode= '" + txbCodeBand.Text + "'";
                    SqlCommand command2 = new SqlCommand(checkBandCode, conn);
                    int temp1 = Convert.ToInt32(command2.ExecuteScalar().ToString());
                    if (temp1 == 1)
                    {
                        txbUserName.Text = "";
                        txbEmail.Text = "";
                        txbCodeBand.Text = "";
                        Label2.Text = "Your band code has already been used";
                    }

                    //The user has not registered before
                    //The user is one of the participants
                    //The user has his/her band code which has not used before.
                    else
                    {
                        //add user data entered in registeration page into UserData table
                        string insertQuery = "insert into UserData (UserName,Email,Password,BandCode) values (@Uname, @email, @password, @bandcode)";
                        SqlCommand command1 = new SqlCommand(insertQuery, conn);
                        command1.Parameters.AddWithValue("@Uname", txbUserName.Text);
                        command1.Parameters.AddWithValue("@email", txbEmail.Text);
                        command1.Parameters.AddWithValue("@password", txbPassword.Text);
                        command1.Parameters.AddWithValue("@bandcode", txbCodeBand.Text);

                        command1.ExecuteNonQuery();

                        txbUserName.Text = "";
                        txbEmail.Text = "";
                        txbCodeBand.Text = "";
                        Label2.Text = "Registeration is successfully completed";
                    }

                }
                //The band code is not correct and the user is not one of the participants
                else
                {
                    txbUserName.Text = "";
                    txbEmail.Text = "";
                    txbCodeBand.Text = "";
                    Label2.Text = "You are not one of the participants, check your band code";

                }              
            }
            conn.Close();          
        }
        catch(Exception ex)
        {
            Label2.Text="Error :"+ex.ToString();
        }*/

    }

    //Function to check the participant band code if it one of the listed in the participantsCodes array

    private bool checkParticipants(string user)
    {
        bool isPar = participantsCodes.Contains(user);
        return isPar;
    }
}