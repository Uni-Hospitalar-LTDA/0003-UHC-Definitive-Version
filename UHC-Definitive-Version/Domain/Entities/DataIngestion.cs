using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.Domain.Entities
{
    public class DataIngestion : Querys<DataIngestion>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string idUser { get; set; }
        public string date { get; set; }

    }
}
