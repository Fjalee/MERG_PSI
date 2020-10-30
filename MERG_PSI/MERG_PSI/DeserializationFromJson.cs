using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MERG_PSI
{
    public class DeserializationFromJson
    {
        private readonly string _filePath = @"../../scrapedData.txt";
        public List<RealEstate> Data { get; set; }

        public DeserializationFromJson()
        {
            var jsonFromFile = ReadFromFile();
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
    }
}