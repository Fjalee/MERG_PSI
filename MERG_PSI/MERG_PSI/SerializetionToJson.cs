using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERG_PSI
{
    class SerializetionToJson
    {
        private void dederialization()
        {
            var filePath = @"C:\Users\Greta\Desktop\text.txt"; // change filePath
            var ad = new List<RealEstate>();

            var jsonToWrite = JsonConvert.SerializeObject(ad);

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonToWrite);
                writer.Close();
            }
        }
    }
}
