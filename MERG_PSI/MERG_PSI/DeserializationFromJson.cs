using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MERG_PSI
{
    
    class DeserializationFromJson
    {
        public List<RealEstate> Data { get; set; }
        public DeserializationFromJson()
        {
            var filePath = "../../scrapedData.txt";

            string jsonFromFIle;
            using (var reader = new StreamReader(filePath))
            {
                jsonFromFIle = reader.ReadToEnd();
                reader.Close();
            }

            Data = JsonConvert.DeserializeObject<List<RealEstate>>(jsonFromFIle);
             
        }
    }
}
