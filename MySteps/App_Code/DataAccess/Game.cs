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
/// Summary description for Game
/// </summary>
public class Game
{
    public Game()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Fuction to insert game data into GameData table including(userid, date, unlockedLevel and timeofplay)
    public static int insertGameData(int userId, DateTime datetim, int unlockedLevel, float timeofPlay)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string insertQuery = "INSERT INTO GameData (UserID,Date,UnLockedLevel,TimeOfPlay) VALUES (@id, @date, @unlocklevel, @timeofplay)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = datetim;
            command.Parameters.Add("@unlocklevel", SqlDbType.Int).Value = unlockedLevel;
            command.Parameters.Add("@timeofplay", SqlDbType.Float).Value = timeofPlay;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }


    //function to update the unlockedlevel in the GameDate table
    //This function should get the date value only without the time
    public static int updateUnlockedLevel(int userId, DateTime datetim, int unlockedLevel)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string updateQuery = "UPDATE GameData SET Date = @date, UnLockedLevel = @unlocklevel WHERE UserID = '" + userId + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command = new SqlCommand(updateQuery, connection);

            command.Parameters.Add("@date", SqlDbType.DateTime).Value = datetim;
            command.Parameters.Add("@unlocklevel", SqlDbType.Int).Value = unlockedLevel;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

    //function to update the time of play in the GameData table
    //This function should get the date value only without the time
    public static int updateTimeOfPlay(int userId, DateTime datetim, float timeOfPlay)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string updateQuery = "UPDATE GameData SET Date = @date, TimeOfPlay = @timeofplay WHERE UserID = '" + userId + "' AND Date>= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND Date < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))";
            SqlCommand command = new SqlCommand(updateQuery, connection);

            command.Parameters.Add("@date", SqlDbType.DateTime).Value = datetim;
            command.Parameters.Add("@timeofplay", SqlDbType.Float).Value = timeOfPlay;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

    //function to get the last unlocked level from the GameData table
    //This function should get the date value only without the time
    public static int getUnLockedLevel(int userId, DateTime datetim)
    {
        int level = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string getLevel = "SELECT UnLockedLevel FROM GameData where UserID = '" + userId + "' AND CAST(GameData.Date as DATE) = '" + datetim + "'";
            SqlCommand command = new SqlCommand(getLevel, connection);

            level = (Int32)command.ExecuteScalar();


            connection.Close();

        }

        return level;
    }

    //function to get the time of play from the GameData table
    //This function should get the date value only without the time
    public static float getTimeOfPlay(int userId, DateTime datetim)
    {
        float timeofPlay = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string getTime = "SELECT TimeOfPlay FROM GameData where UserID = '" + userId + "' AND CAST(GameData.Date as DATE) = '" + datetim + "'";
            SqlCommand command = new SqlCommand(getTime, connection);

            timeofPlay = float.Parse(command.ExecuteScalar().ToString());


            connection.Close();

        }

        return timeofPlay;
    }


}