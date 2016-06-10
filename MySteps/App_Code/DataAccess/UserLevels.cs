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
/// Summary description for UserLevels
/// </summary>
public class UserLevels
{
    public UserLevels()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //Fuction to insert user's level data into UserLevels table including(userid, level, stars, heart)
    public static int insertUserLevel(int userId, int level, int stars, int heart)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string insertQuery = "INSERT INTO UserLevels (UserId,Level,Stars,Hearts) VALUES (@id, @level, @stars, @hearts)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@level", SqlDbType.Int).Value = level;
            command.Parameters.Add("@stars", SqlDbType.Int).Value = stars;
            command.Parameters.Add("@hearts", SqlDbType.Int).Value = heart;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

    //function to update the stars data for a specific level in the UserLevels table
    public static int updateStars(int userId, int level, int stars)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string updateQuery = "UPDATE UserLevels SET Stars = @stars WHERE UserId = '" + userId + "' AND Level = '" + level + "'";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.Add("@stars", SqlDbType.Int).Value = stars;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

    //function to update the hearts data for a specific level in the UserLevels table
    public static int updateHearts(int userId, int level, int hearts)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string updateQuery = "UPDATE UserLevels SET Hearts = @hearts WHERE UserId = '" + userId + "' AND Level = '" + level + "'";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.Add("@hearts", SqlDbType.Int).Value = hearts;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

    //function to get the number of stars in a specific level from the UserLevels table
    public static int getStars(int userId, int level)
    {
        int stars = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string starQuery = "SELECT Stars FROM UserLevels WHERE UserId = '" + userId + "' AND Level = '" + level + "'";
            SqlCommand command = new SqlCommand(starQuery, connection);

            stars = (Int32)command.ExecuteScalar();

            connection.Close();

        }

        return stars;
    }

    //function to get the number of hearts in a specific level from the UserLevels table
    public static int getHearts(int userId, int level)
    {
        int hearts = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string heartsQuery = "SELECT Hearts FROM UserLevels WHERE UserId = '" + userId + "' AND Level = '" + level + "'";
            SqlCommand command = new SqlCommand(heartsQuery, connection);

            hearts = (Int32)command.ExecuteScalar();

            connection.Close();

        }

        return hearts;
    }


}