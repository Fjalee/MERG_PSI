using System.Collections.Generic;


namespace MERG_BackEnd
{
     public class Data
    {
        public List<RealEstate> SampleData { get; set; }
        public Data()
        {
            var des = new DeserializationFromJson();
            SampleData = des.Data;
        }
    }
}
