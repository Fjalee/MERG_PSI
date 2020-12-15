using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WebScraper
{
    public class OutputToJson
    {
        private const string _filePath = @"scrapedData.txt";

        public void WriteToFile(List<RealEstate> listToConvert)
        {
            var _jsonToWrite = JsonConvert.SerializeObject(listToConvert);
            using (var writer = new StreamWriter(_filePath))
            {
                writer.Write(_jsonToWrite);
                writer.Close();
            }
        }
    }
}