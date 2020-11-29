using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MERG_BackEnd
{
    public class DeserializationFromJson
    {
        public List<RealEstate> Data { get; set; }

        public DeserializationFromJson(string fileName)
        {
            var jsonFromFile = ReadFromFile(fileName);
            Data = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFile);
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