using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
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
        }
    }
}