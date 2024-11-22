using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Configuration.Swagger
{
    public class Data
    {
        public bool authenticated { get; set; }
        public string date { get; set; }
        public string expiresDate { get; set; }
        public string token_type { get; set; }
        public string token { get; set; }        
    }
}
