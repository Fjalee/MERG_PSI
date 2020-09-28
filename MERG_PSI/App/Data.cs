using System.Collections.Generic;


namespace App
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
