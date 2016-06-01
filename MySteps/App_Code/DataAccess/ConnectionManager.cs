using System;


using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.SqlClient;


public class ConnectionManager
{
    public static SqlConnection GetDatabaseConnection()
    {
        string connectString = ConfigurationManager.ConnectionStrings["RegisterationConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectString);

        connection.Open();
        return connection;
    }
}