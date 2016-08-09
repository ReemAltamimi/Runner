using System;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PhysicalActivity
/// </summary>
public class PhysicalActivity
{
    public PhysicalActivity()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //This function add Physical activity data into PhysicalActivityData table 
    //including 
    public static int insertPAData(int userId, DateTime dateTim, int steps, float distance, int sMin, int lAMin, int fAMin, int vAMin)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            //Check if the user has already insert his/her data for today, if so, it 
            //will update the record.
            //if not it will insert a new record
            string checkUserId = "select count(*) from PhysicalActivityData where UserID= '" + userId + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command1 = new SqlCommand(checkUserId, connection);
            int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            if (temp == 1)
            {
                string updateQuery = "UPDATE PhysicalActivityData SET DateAndTime = @dateTime, DailySteps = @steps, DistanceWalkedMile = @distance, SedentaryMinutes = @sedMin, LightActiveMinutes = @lightMin, FairlyActiveMinutes = @fairlyMin, VeryActiveMinutes = @veryMin  WHERE UserID = '" + userId + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

                SqlCommand command2 = new SqlCommand(updateQuery, connection);

                command2.Parameters.AddWithValue("@dateTime", dateTim);
                command2.Parameters.AddWithValue("@steps", steps);
                command2.Parameters.AddWithValue("@distance", distance);
                command2.Parameters.AddWithValue("@sedMin", sMin);
                command2.Parameters.AddWithValue("@lightMin", lAMin);
                command2.Parameters.AddWithValue("@fairlyMin", fAMin);
                command2.Parameters.AddWithValue("@veryMin", vAMin);
                rowsAffected = command2.ExecuteNonQuery();
            }
            else
            {
                string insertQuery = "insert into PhysicalActivityData (UserID,DateAndTime,DailySteps,DistanceWalkedMile,SedentaryMinutes,LightActiveMinutes,FairlyActiveMinutes,VeryActiveMinutes) values (@id, @dateTime, @steps, @distance, @sedMin, @lightMin, @fairlyMin, @veryMin)";
                SqlCommand command3 = new SqlCommand(insertQuery, connection);


                command3.Parameters.AddWithValue("@id", userId);
                command3.Parameters.AddWithValue("@dateTime", dateTim);
                command3.Parameters.AddWithValue("@steps", steps);
                command3.Parameters.AddWithValue("@distance", distance);
                command3.Parameters.AddWithValue("@sedMin", sMin);
                command3.Parameters.AddWithValue("@lightMin", lAMin);
                command3.Parameters.AddWithValue("@fairlyMin", fAMin);
                command3.Parameters.AddWithValue("@veryMin", vAMin);

                rowsAffected = command3.ExecuteNonQuery();
            }

            connection.Close();
        }

        return rowsAffected;
    }

    //get last time in date column for a specific user in the date of today
    public static DateTime getLastTimeInserted(int userId)
    {
        DateTime lastTime;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            //select the last time in date column that match the user id and in the date of today
            string checkLastTime = "select Max(DateAndTime) from PhysicalActivityData where UserID= '" + userId + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command1 = new SqlCommand(checkLastTime, connection);
            lastTime = Convert.ToDateTime(command1.ExecuteScalar());
            connection.Close();

        }

        return lastTime;

    }


    //get the number of steps of a specific date 
    public static int getSteps(DateTime dt, int userId)
    {
        int steps = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            //select the last time in date column that match the user id and in the date of today
            string str = "select DailySteps from PhysicalActivityData where UserID= '" + userId + "' AND CAST([DateAndTime] AS DATE) = '" + String.Format("{0:u}", dt) + "'";
            SqlCommand command1 = new SqlCommand(str, connection);
            steps = Convert.ToInt32(command1.ExecuteScalar());
            connection.Close();
        }

        return steps;

    }

    //check if the user has sync his/her steps today
    public static int physicalActivityIsEntered(int userId)
    {
        int temp = 1;
        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            //Check if the user sync his/her data today
            string check = "select count(*) from PhysicalActivityData where UserID= '" + userId + "' AND DateAndTime>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND DateAndTime < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command1 = new SqlCommand(check, connection);
            temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            //if the number of rows that found in the table is zero
            //this means that the user has not yet sync his PA data 
            connection.Close();
        }
        return temp;
    }


//update no of steps in db
    public static void updateSteps(DateTime dt, int userId, int steps)
    {
        int rowsAffected = 0;
        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            //Check if the user has already insert his/her data for today, if so, it 
            //will update the record.
            //if not it will insert a new record
            string checkUserId = "select count(*) from PhysicalActivityData where UserID= '" + userId + "' AND CAST([DateAndTime] AS DATE) = '" + String.Format("{0:u}", dt) + "'";
            SqlCommand command1 = new SqlCommand(checkUserId, connection);
            int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            if (temp == 1)
            {
                string updateQuery = "UPDATE PhysicalActivityData SET DailySteps = @steps WHERE UserID = '" + userId + "' AND CAST([DateAndTime] AS DATE) = '" + String.Format("{0:u}", dt) + "'";

                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("@steps", steps);

                rowsAffected = command.ExecuteNonQuery();
            }
            else
            {
                string insertQuery = "insert into PhysicalActivityData (UserID,DateAndTime,DailySteps) values (@id, @dateTime, @steps)";
                SqlCommand command3 = new SqlCommand(insertQuery, connection);

                command3.Parameters.AddWithValue("@id", userId);
                command3.Parameters.AddWithValue("@dateTime", dt);
                command3.Parameters.AddWithValue("@steps", steps);
                rowsAffected = command3.ExecuteNonQuery();
            }
            connection.Close();
        }      

    }

}