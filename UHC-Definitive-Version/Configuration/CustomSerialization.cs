using System.IO;
using System.Xml.Serialization;

namespace UHC3_Definitive_Version.Configuration
{
    internal class CustomSerialization<T>
    {
        public static void SerializeToXml(string fileName, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static T DeserializeFromXml(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
