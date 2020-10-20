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
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                25, 1308,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Vilniaus m.","Fabijoniskes",1995),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-s-staneviciaus-g-objekto-id-11280-tvarkingas-sviesus-ir-602892",
                68, 1323,3,5,"https://maps.google.com/maps?q=54.7267946,25.2554228", "Vilniaus m.","Fabijoniskes",2000),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                100, 1308,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Vilniaus m.","Fabijoniskes",2012),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                52, 1500,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Vilniaus m.","Fabijoniskes",2005),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                170, 1308,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Vilniaus m.","Fabijoniskes",2020),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                45, 1308,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Klaipėdos m.","Fabijoniskes",1895),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                91, 2000,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Klaipėdos m.","Fabijoniskes",2020),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                45, 1308,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Vilniaus m.","Fabijoniskes",2020),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                155, 500,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Kauno m.","Fabijoniskes",1995),
                new RealEstate ("https://www.kampas.lt/skelbimai/butas-vilniuje-fabijoniskes-l-giros-g-objekto-id-10991-tvarkingas-sviesus-ir-siltas-602893",
                123, 1308,5,2,"https://maps.google.com/maps?q=54.737919,25.2428785", "Kauno m.","Fabijoniskes",1995)

            };
            SampleData = data;
        }
    }
}
