using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MERG_PSI
{
    class OutputToJson
    {
        //fix to relative
        private string _filePath = @"C:\Users\Rytis\Downloads\scrapedData.txt";
        private string _jsonToWrite;

        public OutputToJson(List<RealEstate> listToConvert)
        {
            _jsonToWrite = ConvertToJson(listToConvert);
        }

        private string ConvertToJson(List<RealEstate> listToConvert)
        {
            return JsonConvert.SerializeObject(listToConvert);
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

