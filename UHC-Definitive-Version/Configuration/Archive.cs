using System.Data;

namespace UHC3_Definitive_Version.Configuration
{
    public class Archive
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string titleReport { get; set; }
        public string query { get; set; }
        public string format { get; set; }
        public DataTable data { get; set; }
    }
}
