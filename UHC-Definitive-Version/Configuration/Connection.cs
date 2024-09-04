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
                ($@"Server=localhost;Database={dbBase}");                
                builder.UserID = "sa";
                builder.Password = "rfds3142365.";
                //builder.Password = "rfds3142365.";
                conn = builder.ConnectionString;
                return new SqlConnection(conn);
            }
            else if (unidade == "UNI CEARÁ")
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                    ($@"Server=localhost;Database={dbBase}");
                builder.UserID = "sa";
                builder.Password = "rfds3142365.";
                //builder.Password = "rfds3142365.";
                conn = builder.ConnectionString;
                return new SqlConnection(conn);
                }
            else if (unidade == "SP HOSPITALAR")
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
               ($@"Server=localhost;Database={dbBase}");
                builder.UserID = "sa";
                builder.Password = "rfds3142365.";
                //builder.Password = "rfds3142365.";                
                conn = builder.ConnectionString;
                return new SqlConnection(conn);
            }

            return null;
        }
    }
}
