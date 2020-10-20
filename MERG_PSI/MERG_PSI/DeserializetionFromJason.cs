using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MERG_PSI
{
    class DeserializetionFromJason
    {
        private void dederialization()
        {
            var filePath = @"C:\Users\Greta\Desktop\text2.txt";

            string jsonFromFIle;
            using (var reader = new StreamReader(filePath))
            {
                jsonFromFIle = reader.ReadToEnd();
                reader.Close();
            }

            var advertFromJson = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFIle);
        }
    }
}
