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
/// Summary description for ScreenTime
/// </summary>
public class ScreenTime
{
    public ScreenTime()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int insertSTData(int userId, DateTime dateTim, int screenTime)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            //Check if the user has already insert his/her data for today, if so, it 
            //will update the record.
            //if not it will insert a new record
            string check = "select count(*) from ScreenTimeData where UserID= '" + userId + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command1 = new SqlCommand(check, connection);
            int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            //if the number of rows that found in the table is zero, which means that the user has not yet entered the amount 
            //of screen time of today 
            if (temp == 0)
            {

                string insertQuery = "insert into ScreenTimeData (Date,UserID,UserScreenDailyAmnt) values (@date, @id, @amount)";
                SqlCommand command2 = new SqlCommand(insertQuery, connection);

                command2.Parameters.AddWithValue("@date", dateTim);
                command2.Parameters.AddWithValue("@id", userId);
                command2.Parameters.AddWithValue("@amount", screenTime);

                rowsAffected = command2.ExecuteNonQuery();
            }
            else
            {
                string updateQuery = "UPDATE ScreenTimeData SET Date = @date, UserScreenDailyAmnt = @amount  WHERE UserID = '" + userId + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";

                SqlCommand command3 = new SqlCommand(updateQuery, connection);

                command3.Parameters.AddWithValue("@date", dateTim);
                command3.Parameters.AddWithValue("@amount", screenTime);

                rowsAffected = command3.ExecuteNonQuery();
            }
            connection.Close();
        }

        return rowsAffected;
    }
}