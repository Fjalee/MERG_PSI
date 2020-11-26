using System.Collections.Generic;
using System.IO;

namespace MERG_BackEnd
{
     public class Data
    {
        public List<RealEstate> SampleData { get; set; }
        public Data()
        {
            //var des = new DeserializationFromJson();
            //SampleData = des.Data;
        }
        public Data(Stream stream)
        {
            var des = new DeserializationFromJson(stream);
            SampleData = des.Data;
        }
    }
}
