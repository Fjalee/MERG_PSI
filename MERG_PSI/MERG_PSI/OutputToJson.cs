using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MERG_PSI
{
    class OutputToJson
    {
        private readonly string _filePath = @"scrapedData.txt";
        private readonly string _jsonToWrite;

        public OutputToJson(List<RealEstate> listToConvert)
        {
            _jsonToWrite = JsonConvert.SerializeObject(listToConvert);
        }

        public void WriteToFile()
        {
            using (var writer = new StreamWriter(_filePath))
            {
                writer.Write(_jsonToWrite);
                writer.Close();
            }
        }
    }
}

