using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration.Swagger;

namespace UHC3_Definitive_Version.Configuration.InterplayersWebApi
{
    public class Token
    {
        public bool success { get; set; }        
        public Data data { get; set; }

        public const string rota = @"https://homologacaoesp.interplayers.com.br/INT/Pfizer/WebAPI/api/v1/auth";
        internal async static Task<Token> POST(Credentials cc,string rota)
        {                                 
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{rota}api/v1/auth");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";


            var tokenSerialization = JsonConvert.SerializeObject(cc, Formatting.Indented);

            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                streamWriter.Write(tokenSerialization);
                Console.WriteLine(httpWebRequest.Address);
                Console.WriteLine(tokenSerialization);
            }

            try
            {
                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return (Token)JsonConvert.DeserializeObject(streamReader.ReadToEnd(), (typeof(Token)));
                }
            }
            catch (Exception)
            {
                return (new Token { success = false});
            }
        }
    }
}
