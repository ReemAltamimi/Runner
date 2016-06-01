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
/// Summary description for PostForum
/// </summary>
public class PostForum
{
    public static int insertForum(int titleId, string question, string posterName, DateTime datetim)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = ConnectionManager.GetDatabaseConnection())
        {
            SqlCommand command = new SqlCommand("insertForum", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@titleId", SqlDbType.Int).Value = titleId;
            command.Parameters.Add("@question", SqlDbType.VarChar).Value = question;
            command.Parameters.Add("@posterName", SqlDbType.VarChar).Value = posterName;
            command.Parameters.Add("@dateTim", SqlDbType.DateTime).Value = datetim;

            rowsAffected = command.ExecuteNonQuery();
        }

        return rowsAffected;
    }
}