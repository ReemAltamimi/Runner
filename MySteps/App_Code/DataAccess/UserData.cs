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
/// Summary description for UserData
/// </summary>
public class UserData
{
    public UserData()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //This function add user data into UserData table including user name, email, password and band code
    public static int insertUserData(string userName, string email, string password, string bandCode, char share)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string insertQuery = "insert into UserData (UserName,Email,Password,BandCode,Share,FirstDayAward) values (@Uname, @email, @password, @bandcode,@share,@firstdayaward)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.Add("@Uname", SqlDbType.NChar).Value = userName;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@password", SqlDbType.NChar).Value = password;
            command.Parameters.Add("@bandcode", SqlDbType.NChar).Value = bandCode;
            command.Parameters.Add("@share", SqlDbType.Char).Value = share;
            command.Parameters.Add("@firstdayaward", SqlDbType.Bit).Value = 0;
            

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }


    public static bool getTokens(int userId, out string token, out string refreshToken)
    {
        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string query = "select [Token],[RefreshToken] from UserData where Id=@userId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                token = reader["Token"].ToString();
                refreshToken = reader["RefreshToken"].ToString();
                return token != "";
            }
        }
        token = "";
        refreshToken = "";
        return false;
    }
    //This function add token and referesh token data into UserData table
    public static int insertTokens(int userId, string token, string refreshToken)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string insertQuery = "UPDATE UserData SET Token = @token, RefreshToken = @refreshToken WHERE(Id = @userId)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.AddWithValue("@token", token);
            command.Parameters.AddWithValue("@refreshToken", refreshToken);
            command.Parameters.AddWithValue("@userId", userId);

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

    //get token for a specific user.
    public static string getToken(int userid)
    {
        string token;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string str = "select Token from UserData where Id= '" + userid + "'";
            SqlCommand command = new SqlCommand(str, connection);
            token = command.ExecuteScalar().ToString();
            connection.Close();
        }
        return token;
    }

    //get refresh token for a specific user.
    public static string getRefToken(int userid)
    {
        string reftoken;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string str = "select RefreshToken from UserData where Id= '" + userid + "'";
            SqlCommand command = new SqlCommand(str, connection);
            reftoken = command.ExecuteScalar().ToString();
            connection.Close();
        }
        return reftoken;
    }

    //This function if the user is already exists in the database by checking the email address
    // as the email address is a unique value for each user.
    //It returns 1 in case the user is existed in the db
    public static int checkUser(string email)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string checkUser = "select count(*) from UserData where Email= '" + email + "'";
            SqlCommand command = new SqlCommand(checkUser, connection);
            rowsAffected = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }
        return rowsAffected;
    }

    //This function checks if the band code of the user has not used before (Allow one user with one band)
    //It returns 1 in case the band code has already been used and found in the db
    public static int checkBandCode(string bandCode)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string checkBandCode = "select count(*) from UserData where BandCode= '" + bandCode + "'";
            SqlCommand command = new SqlCommand(checkBandCode, connection);
            rowsAffected = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }
        return rowsAffected;
    }

    //This function checks the login details
    //It takes user name and password and check if they are correct in the database
    //It returns the userId in case they are found and return 0 in case they are not found
    public static int checkLogin(string userName, string password)
    {
        int userId = 0;
        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string checkUserName = "SELECT count(*) from UserData where UserName= '" + userName + "' and Password= '" + password + "'";
            SqlCommand command1 = new SqlCommand(checkUserName, connection);
            int temp = Convert.ToInt32(command1.ExecuteScalar().ToString());
            if (temp != 0)
            {
                    string userIdQuery = "select Id from UserData where UserName= '" + userName + "' and Password= '" + password + "'";
                    SqlCommand command2 = new SqlCommand(userIdQuery, connection);
                    userId = Convert.ToInt32(command2.ExecuteScalar().ToString());
            }
            connection.Close();
        }

        return userId;
    }


    //get BandCode for a specific user.
    public static string getBandCode(int userid)
    {
        string bandCode;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string str = "select BandCode from UserData where Id= '" + userid + "'";
            SqlCommand command = new SqlCommand(str, connection);
            bandCode = command.ExecuteScalar().ToString();
            connection.Close();
        }
        return bandCode;
    }

    //get share authorization for a specific user.
    public static string getShareAuth(int userid)
    {
        string share;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string str = "select Share from UserData where Id= '" + userid + "'";
            SqlCommand command = new SqlCommand(str, connection);
            share = command.ExecuteScalar().ToString();
            connection.Close();
        }
        return share;
    }
    //get first day award value for a specific user.
    public static int getFisrtDayAward(int userid)
    {
        int firstDayAward;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string str = "select FirstDayAward from UserData where Id= '" + userid + "'";
            SqlCommand command = new SqlCommand(str, connection);
            firstDayAward = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
        }
        return firstDayAward;
    }
    //This function set the firstDayAward data in UserData table to true as the user 
    //got the first day award
    public static int SetFisrtDayAwardToTrue(int userId)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            string insertQuery = "UPDATE UserData SET FirstDayAward = @firstdayaward WHERE(Id = @userId)";
            SqlCommand command = new SqlCommand(insertQuery, connection);

            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.Add("@firstdayaward", SqlDbType.Bit).Value = 1;

            rowsAffected = command.ExecuteNonQuery();

            connection.Close();
        }

        return rowsAffected;
    }

}