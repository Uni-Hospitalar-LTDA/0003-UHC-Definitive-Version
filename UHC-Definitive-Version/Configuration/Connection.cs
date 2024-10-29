using System.Data.SqlClient;
namespace UHC3_Definitive_Version.Configuration
{
    public class Connection
    {
        public const string dbBase = "UHCDB";
        public const string dbDMD = "DMD";

        private static readonly Connection iSQL = new Connection();

        /** Gets **/
        public static Connection getInstancia()
        {
            return iSQL;
        }
        public SqlConnection getConnectionApp(string unidade)
        {
            string conn = null;

            if (unidade == "UNI HOSPITALAR")
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                ($@"Server=10.5.1.42;Database={dbBase}");
                //($@"Server=10.5.1.34;Database={dbBase}");
                builder.UserID = "sa";
                builder.Password = "vls021130";
                //builder.Password = "rfds3142365.";
                conn = builder.ConnectionString;
                return new SqlConnection(conn);
            }
            else if (unidade == "UNI CEARÁ")
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                    ($@"Server=10.5.1.23;Database={dbBase}");
                builder.UserID = "sa";
                builder.Password = "vls021130";
                //builder.Password = "rfds3142365.";
                conn = builder.ConnectionString;
                return new SqlConnection(conn);
                }
            else if (unidade == "SP HOSPITALAR")
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
               ($@"Server=10.5.1.30;Database={dbBase}");
                builder.UserID = "sa";
                builder.Password = "vls021130";
                //builder.Password = "rfds3142365.";                
                conn = builder.ConnectionString;
                return new SqlConnection(conn);
            }

            return null;
        }
    }
}
