using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MERG_BackEnd
{
    public class DeserializationFromJson
    {
        private readonly string fileName;
        public List<RealEstate> Data { get; set; }

        public DeserializationFromJson(string fileName)
        {
            var jsonFromFile = ReadFromFile(fileName);
            Data = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFile);
            fileName = ConfigurationManager.AppSettings.Get("SCRAPED_DATA_FILE_NAME");
        }
        public DeserializationFromJson(Stream stream)
        {
            var jsonFromFile = ReadFromFile(stream);
            Data = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFile);
        }

        private string ReadFromFile(string fileName)
        {
            var textFromFile = "";
            using (var reader = new StreamReader(fileName))
            {
                textFromFile = reader.ReadToEnd();
                reader.Close();
            }

            return textFromFile;
        }
        private string ReadFromFile(Stream stream)
        {
            var textFromFile = "";
            using (var reader = new StreamReader(stream))
            {
                textFromFile = reader.ReadToEnd();
                reader.Close();
            }

            return textFromFile;
        }
 
    }
}