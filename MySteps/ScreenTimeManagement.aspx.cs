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
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            if(txbScreenUnits.Text == null)
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "You have not yet entered a value above, <br> Please enter the screen time amount and then click submit button";
            }
            else
            {
                if (float.Parse(txbScreenUnits.Text) != 0.0)
                {
                    //add screen time data into ScreenTimeData table
                    ScreenTime.insertSTData(Convert.ToInt32(userId), DateTime.Now, float.Parse(txbScreenUnits.Text.Trim()));
                    //show successful message
                    Label3.ForeColor = System.Drawing.Color.Green;
                    Label3.Text = "Your Screen Time has been added <br> Click on View Chart button ";
                    //clear the textbox
                    txbScreenUnits.Text = "";
                }
                else
                {
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label3.Text = "You entered incorrect value above, <br> Please enter the screen time amount and then click submit button";

                }
            }
            
        }
        catch (Exception)
        {
            Label3.ForeColor = System.Drawing.Color.Red;
            Label3.Text = "You have not yet entered a correct value above, <br> Please enter the screen time amount and then click submit button";
            //Label3.Text = "Exception caught." + exp;
           // Response.Output.Write("<p>{0} Exception caught.</p>", exp);
        }

    }
    protected void btnViewChart_Click(object sender, EventArgs e)
    {
        try
        {
            //check if the user has entered his/her screen time amount for today
            int screenAmountIsEntered = ScreenTime.screenTimeIsEntered(Convert.ToInt32(userId));
            if (screenAmountIsEntered == 0)
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "You have not yet enter the screen time amount for today, <br> Please enter the amount and then click submit button";
            }
            else
            {
                DateTime lastTime = ScreenTime.getLastTimeInserted(Convert.ToInt32(userId));

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
                Label3.Text = "Last data updated in " + lastTime.ToString();

            }
        }
        catch (Exception exp)
        {
            Label3.Text = "Exception caught." + exp;
        }

    }
   
}