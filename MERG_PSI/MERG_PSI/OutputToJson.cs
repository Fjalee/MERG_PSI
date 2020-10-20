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

        public OutputToJson()
        {
            var jsonToWrite = ConvertToJson();
            WriteToFile(jsonToWrite);
        }

        private string ConvertToJson()
        {
            var ad = new List<RealEstate>();
            return JsonConvert.SerializeObject(ad);
        }

        private void WriteToFile(string jsonToWrite)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                writer.Write(jsonToWrite);
                writer.Close();
            }
        }
    }
}

