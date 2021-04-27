using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleAppExperiment
{
    static class DataSerializer<T>
    {

        public static void XmlSerialize(T data, string filePath)
        {

            var xmlSerializer = new XmlSerializer(typeof(T));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(textWriter, data);
            }


        }

        public static T XmlDeserializer(string filePath)
        {

            T obj = default;

            var xmlSerializer = new XmlSerializer(typeof(T));

            if (File.Exists(filePath))
            {
                using (TextReader textReader = new StreamReader(filePath))
                {
                    obj = (T)xmlSerializer.Deserialize(textReader);
                }
            }

            return obj;
        }

        public static void JsonSerialize(T data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }


            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(jsonWriter, data, typeof(T));
                }
            }


        }

        public static T JsonDeserialize(string filePath)
        {

            T obj = default;

            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath))
            {

                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    using (JsonReader jsonReader = new JsonTextReader(streamReader))
                    {

                        obj = jsonSerializer.Deserialize<T>(jsonReader);

                    }


                }


            }

            return obj;
        }


        public static void Json2Xml(string jsonFilePath)
        {

            string json = File.ReadAllText(jsonFilePath);

            Console.WriteLine(json);

            //var node = JsonConvert.DeserializeXNode(json);
            var node = JsonConvert.DeserializeXmlNode(json);

            node.Save("ConvertedFromJsonFile.xml");

        }

    }
}