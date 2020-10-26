using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERG_PSI
{
     class Data
    {
        public List<RealEstate> SampleData { get; set; }
        public Data()
        {
            var data = new List<RealEstate>
            {
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 69, pricePerSqM: 1596, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Vilniaus m.",city: "Vilnius", street: "Didlaukio g.",houseNm: "47", coordinates:"60.93333,10.69250",buildYear: 1995 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 25, pricePerSqM: 2000, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Vilniaus m.",city: "Vilnius", street: "Senamiesčio g.",houseNm: "47", coordinates:"56.30889,22.34167",buildYear: 1895 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-s-staneviciaus-g-objekto-id-11280-tvarkingas-sviesus-ir-602892",area: 420, pricePerSqM: 1500, numberOfRooms: 12, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Vilniaus m.",city: "Vilnius", street: "Stanevičiaus g.",houseNm: "47", coordinates:"54.55306,23.35417",buildYear: 2000 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 52, pricePerSqM: 1308, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Vilniaus m.",city: "Vilnius", street: "Didlaukio g.",houseNm: "49", coordinates:"54.89806,23.90361",buildYear: 2001 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 83, pricePerSqM: 1596, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Vilniaus m.",city: "Vilnius", street: "Didlaukio g.",houseNm: "52", coordinates:"54.68333,25.28333",buildYear: 2019 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 85, pricePerSqM: 1596, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Kauno m.",city: "Kaunas", street: "Vytauto g.",houseNm: "59", coordinates:"55.71222,21.13528",buildYear: 1995 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 69, pricePerSqM: 1596, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Kauno m.",city: "Kaunas", street: "Vytauto g.",houseNm: "12", coordinates:"55.73444,24.35750",buildYear: 1995 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 120, pricePerSqM: 1596, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Kauno m.",city: "Kaunas", street: "Vytauto g.",houseNm: "13", coordinates:"55.93611,23.32222",buildYear: 1995 ),
                new RealEstate (link:"https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",area: 351, pricePerSqM: 1596, numberOfRooms: 5, floor:  "3",construction: "blokinis", heating:"centrinis",mapLink:"https://maps.google.com/maps?q=54.7267946,25.2554228",municipality: "Vilniaus m.",city: "Vilnius", street: "Didlaukio g.",houseNm: "14", coordinates:"54.39583,24.04583",buildYear: 1995 )
            };
            SampleData = data;
        }
    }
}
