using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Net;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //changer the header div background
        ((HtmlGenericControl)this.Page.Master.FindControl("header")).Style.Add("background", "#80FF80");


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            SendMail();
            lblError.Text = "Your enquiry has been sent";
            lblError.Visible = true;
            txbSubject.Text = "";
            txbEmail.Text = "";
            txbUserName.Text = "";
            txbText.Text = "";
        }
        catch (Exception)
        {
            lblError.Text = "**Error: Your enquiry has not sent";
        }



        /*try
        {
            MailMessage emailMsg = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            emailMsg.From = new MailAddress(txbEmail.Text);
            emailMsg.To.Add(new MailAddress("mystepsnewcastle@gmail.com"));
            emailMsg.Subject = txbSubject.Text;
            emailMsg.Body = txbText.Text;
            emailMsg.Priority = MailPriority.Normal;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("mystepsnewcastle@gmail.com", "Reem123456");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(emailMsg);

            lblError.Text="Your enquiry has been sent";

        }
        catch
        {
            lblError.Text = "**Your enquiry has not sent";
        }*/
    }

    protected void SendMail()
    {
        // Gmail Address from where you send the mail
        var fromAddress = "mystepsnewcastle@gmail.com";
        // any address where the email will be sending
        var toAddress = "c3107877@uon.edu.au";
        //Password of your gmail address
        const string fromPassword = "Reem123456";
        // Passing the values and make a email formate to display
        string subject = txbSubject.Text.ToString();
        string body = "From: " + txbUserName.Text + "\n";
        body += "Email: " + txbEmail.Text + "\n";
        body += "Subject: " + txbSubject.Text + "\n";
        body += "Question: \n" + txbText.Text + "\n";
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
    }


}