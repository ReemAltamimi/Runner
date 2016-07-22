using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUserData_Click(object sender, EventArgs e)
    {
        String query = "select * from UserData";
        GetTableData(query);
    }

    protected void btnScrnTimData_Click(object sender, EventArgs e)
    {
        String query = "select * from ScreenTimeData";
        GetTableData(query);

    }

    protected void btnPhysicalData_Click(object sender, EventArgs e)
    {
        String query = "select * from PhysicalActivityData";
        GetTableData(query);
    }

    protected void btnGameData_Click(object sender, EventArgs e)
    {
        String query = "select * from GameData";
        GetTableData(query);
    }

    protected void btnUserLevels_Click(object sender, EventArgs e)
    {
        String query = "select * from UserLevels";
        GetTableData(query);
    }

    protected void btnUserPhysicalScreen_Click(object sender, EventArgs e)
    {
        if(txbUserId.Text.Equals(""))
        {
            lblError.Text = "Enter User Id";
        }
        else
        {
            String query = "SELECT UserName, Id, DateAndTime, DailySteps, '' as Date, '' as UserScreenDailyAmnt from UserData, PhysicalActivityData"
          + " where UserData.Id = PhysicalActivityData.UserID AND Id = '" + Convert.ToInt32(txbUserId.Text) + "'"
          + " UNION ALL "
          + "SELECT UserName, Id, '' as DateAndTime, '' as DailySteps, Date, UserScreenDailyAmnt from UserData, ScreenTimeData"
          + " where UserData.Id = ScreenTimeData.UserID AND Id = '" + Convert.ToInt32(txbUserId.Text) + "'";
            GetTableData(query);
        }
      
    }

    protected void btnUserGameLevels_Click(object sender, EventArgs e)
    {
        if (txbUserId.Text.Equals(""))
        {
            lblError.Text = "Enter User Id";
        }
        else
        {
            String query = "SELECT UserName, Id, Date, UnLockedLevel, TimeOfPlay, '' as Date, '' as Level, '' as Stars, '' as Hearts from UserData, GameData"
          + " where UserData.Id = GameData.UserID AND Id = '" + Convert.ToInt32(txbUserId.Text) + "'"
          + " UNION ALL "
          + " SELECT UserName, Id, '' as Date, '' as UnLockedLevel, '' as TimeOfPlay, Date, Level, Stars, Hearts from UserData, UserLevels"
          + " where UserData.Id = UserLevels.UserId AND Id = '" + Convert.ToInt32(txbUserId.Text) + "'";
            GetTableData(query);
        }
    }

    protected void btnForum_Click(object sender, EventArgs e)
    {
        String query = "select * from Forum";
        GetTableData(query);
    }

    protected void btnThread_Click(object sender, EventArgs e)
    {
        String query = "select * from Thread";
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



    protected void btnReminder_Click(object sender, EventArgs e)
    {
        /*try
        {
            // Gmail Address from where you send the mail
            var fromAddress = "mystepsnewcastle@gmail.com";
            // any address where the email will be sending
            var toAddress = "c3107877@uon.edu.au, " + getUsersEmails();
            //Password of your gmail address
            const string fromPassword = "Reem123456";
            // Passing the values and make a email formate to display
            string subject = "Reminder";
            string body = "Hi, Have you visit Mysteps website today";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
            lblError.Text = "Reminders were sent";
        }
        catch(Exception)
        {
            lblError.Text = "Error Caught";
        }*/



        // Gmail Address from where you send the mail
        var fromAddress = "mystepsnewcastle@gmail.com";
        //Password of your gmail address
        const string fromPassword = "Reem123456";

        MailAddress from = new MailAddress("mystepsnewcastle@gmail.com");
        MailAddress to = new MailAddress("c3107877@uon.edu.au");
        MailMessage message = new MailMessage(from, to);
        // message.Subject = "Using the SmtpClient class.";
        message.Subject = "Reminder";
        message.Body = @"Hi, Have you visit Mysteps website today";
        // Add a carbon copy recipient.
        MailAddress copy = new MailAddress(getUsersEmails()+"topof2007@hotmail.com");
        message.Bcc.Add(copy);
        // smtp settings
       
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
         
        try
        {
            smtp.Send(message);
            lblError.Text = "Reminders were sent";
        }
        catch (Exception ex)
        {
            lblError.Text = "Error Caught" + ex.ToString();
        }

    }

    public string getUsersEmails()
    {
        string emailsList = "";
        try
        {
            //System.Data.SqlClient.SqlDataReader dr = null;
            using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT [Email] FROM [UserData]", connection);

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!String.IsNullOrEmpty(emailsList))
                        {
                            emailsList += ", ";
                        }
                        emailsList += reader["Email"].ToString();
                    }
                }
                connection.Close();       

            }
        }
        catch (Exception)
        {
            lblError.Text = "Error Caught";
        }

        return emailsList;
    }
}