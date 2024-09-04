using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Configuration
{
    public class Connection
    {
        public const string dbBase = "DMD";

        private static readonly Connection iSQL = new Connection();

        /** Gets **/
        public static Connection getInstancia()
        {
            return iSQL;
        }
        public SqlConnection getConnectionApp(string unidade)
        {
            string conn = null;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            ($@"Server=10.5.1.42;Database={dbBase}");
            //($@"Server=localhost;Database={dbBase}");
            builder.UserID = "sa";
            builder.Password = "vls021130";
            //builder.Password = "rfds3142365.";
            conn = builder.ConnectionString;
            return new SqlConnection(conn);
        }
    }
}
