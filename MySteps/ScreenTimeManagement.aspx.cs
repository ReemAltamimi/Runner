using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class ScreenTimeManagement : System.Web.UI.Page
{
    string userId;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the user is login in the system
        if (Session["UserId"] == null)
        {
            Response.Redirect("Default");
            return;
        }

        userId = Session["UserId"].ToString();
        Session["Date"] = DateTime.Now;
        
        //if (IsPostBack)
        //{
            //get the user id
          //  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
          //  conn.Open();
          //  string userIdQuery = "select Id from UserData where UserName= '" + Session["New"].ToString() + "'";
          //  SqlCommand command = new SqlCommand(userIdQuery, conn);
           // userId = command.ExecuteScalar().ToString().Replace(" ", "");
           // conn.Close();
       // }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            //add screen time data into ScreenTimeData table
            ScreenTime.insertSTData(Convert.ToInt32(userId), DateTime.Now, Convert.ToInt32(txbScreenUnits.Text));
            //show successful message
            Label3.ForeColor = System.Drawing.Color.Green;
            Label3.Text = "Your Screen Time has been added <br> click on View Chart button ";
            //clear the textbox
            txbScreenUnits.Text = "";

            /* SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
             conn.Open();

             //select the row that match the current session user id and match the date of today
             string checkUser = "select count(*) from ScreenTimeData where UserID= '" + Session["UserId"] + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
             SqlCommand command1 = new SqlCommand(checkUser, conn);
             int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
             //if the number of rows that found in the table is zero, which means that the user has not yet entered the amount 
             //of screen time of today 
             if (temp == 0)
             {

                 string insertQuery = "insert into ScreenTimeData (Date,UserID,UserScreenDailyAmnt) values (@date, @id, @amount)";
                 SqlCommand command = new SqlCommand(insertQuery, conn);

                 command.Parameters.AddWithValue("@date", Session["Date"]);
                 command.Parameters.AddWithValue("@id", Convert.ToInt32(userId));
                 command.Parameters.AddWithValue("@amount", Convert.ToInt32(txbScreenUnits.Text));

                 command.ExecuteNonQuery();
                 //show successful message
                 Label3.ForeColor = System.Drawing.Color.Green;
                 Label3.Text = "Your Screen Time has been added <br> click on View Chart button ";
                 //clear the textbox
                 txbScreenUnits.Text = "";
             }
             else
             {
                 string updateQuery = "UPDATE ScreenTimeData SET Date = @date, UserScreenDailyAmnt = @amount  WHERE UserID = '" + userId + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

                 SqlCommand command3 = new SqlCommand(updateQuery, conn);

                 command3.Parameters.AddWithValue("@date", Session["Date"]);
                 command3.Parameters.AddWithValue("@amount", Convert.ToInt32(txbScreenUnits.Text));

                 command3.ExecuteNonQuery();

                 //show successful message
                 Label3.ForeColor = System.Drawing.Color.Green;
                 Label3.Text = "Your Screen Time has been updated <br> click on View Chart button ";
                 //clear the textbox
                 txbScreenUnits.Text = "";
             }

             conn.Close();  */

        }
        catch
        {
            //check if the user has not yet entered his screen time amount for today
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
            conn.Open();
            //select the row that match the current session user id and match the date of today
            string checkUser = "select count(*) from ScreenTimeData where UserID= '" + Session["UserId"] + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command1 = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            //if the number of rows that found in the table is zero, which means that the user has not yet entered the amount 
            //of screen time of today an error message will appear
            if (temp == 0)
            {

                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "You have not yet enter the screen time amount of today, <br> please enter the amount and then click submit button";
            }
            conn.Close();
        }

    }
    protected void btnViewChart_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString);
        conn.Open();
        DateTime lastTime;
        //select the last time in date column that match the current session user id and in the date of today
        string  checkLastTime = "select Max(Date) from ScreenTimeData where UserID= '" + Session["UserId"] + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
        SqlCommand command1 = new SqlCommand(checkLastTime, conn);
        lastTime = Convert.ToDateTime(command1.ExecuteScalar());

        conn.Close();

        //set the last time for chart data customization
        Session["LastTime"] = lastTime;

        //to limit the axis X data
        double startDate = DateTime.Now.AddDays(-1).ToOADate();
        double endDate = DateTime.Now.AddDays(1).ToOADate();

        //limit the values that appear in x axis 
        ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.Minimum = startDate;
        ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.Maximum = endDate;
        //to show each single day in x axis
        ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        //to show the x axis labels vertically
        ScreenTimeChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 90;
        //set the width of series column in the chart
        ScreenTimeChart.Series["UserScreenAmount"]["PixelPointWidth"] = "30";
        ScreenTimeChart.Series["ScreenLimit"]["PixelPointWidth"] = "30";

        


        //Show the Screen time chart
        ScreenTimeChart.Visible = true;
        Label3.ForeColor = System.Drawing.Color.Green;
        Label3.Text = "Last data updated in "+ lastTime.ToString();

    }
   
}