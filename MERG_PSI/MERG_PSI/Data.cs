using System.Collections.Generic;


namespace MERG_PSI
{
     class Data
    {
        public List<RealEstate> SampleData { get; set; }
        public Data()
        {
            var des = new DeserializationFromJson();
            SampleData = des.Data;
        }
    }
}
