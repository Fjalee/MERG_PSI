using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MERG_BackEnd
{
    public class DeserializationFromJson
    {
        private const string _filePath = @"../../scrapedData.txt";
        public List<RealEstate> Data { get; set; }

        public DeserializationFromJson()
        {
            var jsonFromFile = ReadFromFile();
            Data = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFile);
        }
        public DeserializationFromJson(Stream stream)
        {
            var jsonFromFile = ReadFromFile(stream);
            Data = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFile);
        }

        private string ReadFromFile()
        {
            var textFromFile = "";
            using (var reader = new StreamReader(_filePath))
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