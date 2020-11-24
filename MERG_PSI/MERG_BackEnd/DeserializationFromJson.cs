
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MERG_BackEnd
{
    class DeserializationFromJson
    {
        private const string _filePath = @"../../scrapedData.txt";
        public List<RealEstateModel> Data { get; set; }

        public DeserializationFromJson()
        {
            var jsonFromFile = ReadFromFile();
            Data = JsonConvert.DeserializeObject<List<RealEstateModel>>(jsonFromFile);
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