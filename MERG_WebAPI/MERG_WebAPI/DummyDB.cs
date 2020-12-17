using System;
using System.Collections.Generic;
using System.Text;

namespace MERG_BackEnd
{
    class DummyDB
    {
        public List<RealEstate> ListOfRealEstates { get; set; } = new List<RealEstate>
        {
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
            new RealEstate(),
        };


        public DummyDB()
        {
            ListOfRealEstates[0].Link = "noSampleLink";
            ListOfRealEstates[1].Link = "SampleLink1";
            ListOfRealEstates[2].Link = "SampleLink2";
            ListOfRealEstates[3].Link = "SampleLink3";
            ListOfRealEstates[4].Link = "SampleLink4";
            ListOfRealEstates[5].Link = "SampleLink5";
            ListOfRealEstates[6].Link = "SampleLink6";
            ListOfRealEstates[7].Link = "SampleLink7";
            ListOfRealEstates[8].Link = "SampleLink8";
            ListOfRealEstates[9].Link = "SampleLink9";

            ListOfRealEstates[0].Area = 0;
            ListOfRealEstates[1].Area = 10;
            ListOfRealEstates[2].Area = 20;
            ListOfRealEstates[3].Area = 30;
            ListOfRealEstates[4].Area = 40;
            ListOfRealEstates[5].Area = 50;
            ListOfRealEstates[6].Area = 60;
            ListOfRealEstates[7].Area = 70;
            ListOfRealEstates[8].Area = 80;
            ListOfRealEstates[9].Area = 90;

            ListOfRealEstates[0].PricePerSqM = 0;
            ListOfRealEstates[1].PricePerSqM = 100;
            ListOfRealEstates[2].PricePerSqM = 200;
            ListOfRealEstates[3].PricePerSqM = 300;
            ListOfRealEstates[4].PricePerSqM = 400;
            ListOfRealEstates[5].PricePerSqM = 500;
            ListOfRealEstates[6].PricePerSqM = 600;
            ListOfRealEstates[7].PricePerSqM = 700;
            ListOfRealEstates[8].PricePerSqM = 800;
            ListOfRealEstates[9].PricePerSqM = 900;

            ListOfRealEstates[0].NumberOfRooms = 0;
            ListOfRealEstates[1].NumberOfRooms = 1;
            ListOfRealEstates[2].NumberOfRooms = 2;
            ListOfRealEstates[3].NumberOfRooms = 3;
            ListOfRealEstates[4].NumberOfRooms = 4;
            ListOfRealEstates[5].NumberOfRooms = 5;
            ListOfRealEstates[6].NumberOfRooms = 6;
            ListOfRealEstates[7].NumberOfRooms = 7;
            ListOfRealEstates[8].NumberOfRooms = 8;
            ListOfRealEstates[9].NumberOfRooms = 9;

            ListOfRealEstates[0].Floor = "0";
            ListOfRealEstates[1].Floor = "1";
            ListOfRealEstates[2].Floor = "2";
            ListOfRealEstates[3].Floor = "3";
            ListOfRealEstates[4].Floor = "4";
            ListOfRealEstates[5].Floor = "5";
            ListOfRealEstates[6].Floor = "6";
            ListOfRealEstates[7].Floor = "7";
            ListOfRealEstates[8].Floor = "8";
            ListOfRealEstates[9].Floor = "9";

            ListOfRealEstates[0].Price = 0;
            ListOfRealEstates[1].Price = 10000;
            ListOfRealEstates[2].Price = 20000;
            ListOfRealEstates[3].Price = 30000;
            ListOfRealEstates[4].Price = 40000;
            ListOfRealEstates[5].Price = 50000;
            ListOfRealEstates[6].Price = 60000;
            ListOfRealEstates[7].Price = 70000;
            ListOfRealEstates[8].Price = 80000;
            ListOfRealEstates[9].Price = 90000;

            ListOfRealEstates[0].MapLink = "noSampleMapLink";
            ListOfRealEstates[1].MapLink = "SampleMapLink1";
            ListOfRealEstates[2].MapLink = "SampleMapLink2";
            ListOfRealEstates[3].MapLink = "SampleMapLink3";
            ListOfRealEstates[4].MapLink = "SampleMapLink4";
            ListOfRealEstates[5].MapLink = "SampleMapLink5";
            ListOfRealEstates[6].MapLink = "SampleMapLink6";
            ListOfRealEstates[7].MapLink = "SampleMapLink7";
            ListOfRealEstates[8].MapLink = "SampleMapLink8";
            ListOfRealEstates[9].MapLink = "SampleMapLink9";

            ListOfRealEstates[0].Municipality = "noMunicipality";
            ListOfRealEstates[1].Municipality = "SampleMunicipality1";
            ListOfRealEstates[2].Municipality = "SampleMunicipality2";
            ListOfRealEstates[3].Municipality = "SampleMunicipality3";
            ListOfRealEstates[4].Municipality = "SampleMunicipality4";
            ListOfRealEstates[5].Municipality = "SampleMunicipality5";
            ListOfRealEstates[6].Municipality = "SampleMunicipality6";
            ListOfRealEstates[7].Municipality = "SampleMunicipality7";
            ListOfRealEstates[8].Municipality = "SampleMunicipality8";
            ListOfRealEstates[9].Municipality = "SampleMunicipality9";

            ListOfRealEstates[0].Microdistrict = "noMicrodistrict";
            ListOfRealEstates[1].Microdistrict = "SampleMicrodistrict1";
            ListOfRealEstates[2].Microdistrict = "SampleMicrodistrict2";
            ListOfRealEstates[3].Microdistrict = "SampleMicrodistrict3";
            ListOfRealEstates[4].Microdistrict = "SampleMicrodistrict4";
            ListOfRealEstates[5].Microdistrict = "SampleMicrodistrict5";
            ListOfRealEstates[6].Microdistrict = "SampleMicrodistrict6";
            ListOfRealEstates[7].Microdistrict = "SampleMicrodistrict7";
            ListOfRealEstates[8].Microdistrict = "SampleMicrodistrict8";
            ListOfRealEstates[9].Microdistrict = "SampleMicrodistrict9";

            ListOfRealEstates[0].Street = "noStreet";
            ListOfRealEstates[1].Street = "SampleStreet1";
            ListOfRealEstates[2].Street = "SampleStreet2";
            ListOfRealEstates[3].Street = "SampleStreet3";
            ListOfRealEstates[4].Street = "SampleStreet4";
            ListOfRealEstates[5].Street = "SampleStreet5";
            ListOfRealEstates[6].Street = "SampleStreet6";
            ListOfRealEstates[7].Street = "SampleStreet7";
            ListOfRealEstates[8].Street = "SampleStreet8";
            ListOfRealEstates[9].Street = "SampleStreet9";

            ListOfRealEstates[0].BuildYear = 1990;
            ListOfRealEstates[1].BuildYear = 1991;
            ListOfRealEstates[2].BuildYear = 1992;
            ListOfRealEstates[3].BuildYear = 1993;
            ListOfRealEstates[4].BuildYear = 1994;
            ListOfRealEstates[5].BuildYear = 1995;
            ListOfRealEstates[6].BuildYear = 1996;
            ListOfRealEstates[7].BuildYear = 1997;
            ListOfRealEstates[8].BuildYear = 1998;
            ListOfRealEstates[9].BuildYear = 1999;

            ListOfRealEstates[0].Image = "noImage";
            ListOfRealEstates[1].Image = "SampleImage1";
            ListOfRealEstates[2].Image = "SampleImage2";
            ListOfRealEstates[3].Image = "SampleImage3";
            ListOfRealEstates[4].Image = "SampleImage4";
            ListOfRealEstates[5].Image = "SampleImage5";
            ListOfRealEstates[6].Image = "SampleImage6";
            ListOfRealEstates[7].Image = "SampleImage7";
            ListOfRealEstates[8].Image = "SampleImage8";
            ListOfRealEstates[9].Image = "SampleImage9";

            ListOfRealEstates[0].Latitude = 54.90;
            ListOfRealEstates[1].Latitude = 54.91;
            ListOfRealEstates[2].Latitude = 54.92;
            ListOfRealEstates[3].Latitude = 54.93;
            ListOfRealEstates[4].Latitude = 54.94;
            ListOfRealEstates[5].Latitude = 54.95;
            ListOfRealEstates[6].Latitude = 54.96;
            ListOfRealEstates[7].Latitude = 54.97;
            ListOfRealEstates[8].Latitude = 54.98;
            ListOfRealEstates[9].Latitude = 54.99;

            ListOfRealEstates[0].Longitude = 23.90;
            ListOfRealEstates[1].Longitude = 23.91;
            ListOfRealEstates[2].Longitude = 23.92;
            ListOfRealEstates[3].Longitude = 23.93;
            ListOfRealEstates[4].Longitude = 23.94;
            ListOfRealEstates[5].Longitude = 23.95;
            ListOfRealEstates[6].Longitude = 23.96;
            ListOfRealEstates[7].Longitude = 23.97;
            ListOfRealEstates[8].Longitude = 23.98;
            ListOfRealEstates[9].Longitude = 23.99;
        }

        //    ListOfRealEstates[0].Link = "sampleLink1";
        //    ListOfRealEstates[0].Area = 50;
        //    ListOfRealEstates[0].PricePerSqM = 50;
        //    ListOfRealEstates[0].NumberOfRooms = 50;
        //    ListOfRealEstates[0].Floor = "sampleFloor50";
        //    ListOfRealEstates[0].Price = 50;
        //    ListOfRealEstates[0].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[0].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[0].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[0].Street = "sampleStreet50";
        //    ListOfRealEstates[0].BuildYear = 50;
        //    ListOfRealEstates[0].Image = "sampleImage50";
        //    ListOfRealEstates[0].Latitude = 50.0;
        //    ListOfRealEstates[0].Longitude = 50.0;

        //    ListOfRealEstates[1].Link = "sampleLink50";
        //    ListOfRealEstates[1].Area = 50;
        //    ListOfRealEstates[1].PricePerSqM = 50;
        //    ListOfRealEstates[1].NumberOfRooms = 50;
        //    ListOfRealEstates[1].Floor = "sampleFloor50";
        //    ListOfRealEstates[1].Price = 50;
        //    ListOfRealEstates[1].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[1].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[1].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[1].Street = "sampleStreet50";
        //    ListOfRealEstates[1].BuildYear = 50;
        //    ListOfRealEstates[1].Image = "sampleImage50";
        //    ListOfRealEstates[1].Latitude = 50.0;
        //    ListOfRealEstates[1].Longitude = 50.0;

        //    ListOfRealEstates[2].Link = "sampleLink50";
        //    ListOfRealEstates[2].Area = 50;
        //    ListOfRealEstates[2].PricePerSqM = 50;
        //    ListOfRealEstates[2].NumberOfRooms = 50;
        //    ListOfRealEstates[2].Floor = "sampleFloor50";
        //    ListOfRealEstates[2].Price = 50;
        //    ListOfRealEstates[2].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[2].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[2].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[2].Street = "sampleStreet50";
        //    ListOfRealEstates[2].BuildYear = 50;
        //    ListOfRealEstates[2].Image = "sampleImage50";
        //    ListOfRealEstates[2].Latitude = 50.0;
        //    ListOfRealEstates[2].Longitude = 50.0;

        //    ListOfRealEstates[3].Link = "sampleLink50";
        //    ListOfRealEstates[3].Area = 50;
        //    ListOfRealEstates[3].PricePerSqM = 50;
        //    ListOfRealEstates[3].NumberOfRooms = 50;
        //    ListOfRealEstates[3].Floor = "sampleFloor50";
        //    ListOfRealEstates[3].Price = 50;
        //    ListOfRealEstates[3].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[3].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[3].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[3].Street = "sampleStreet50";
        //    ListOfRealEstates[3].BuildYear = 50;
        //    ListOfRealEstates[3].Image = "sampleImage50";
        //    ListOfRealEstates[3].Latitude = 50.0;
        //    ListOfRealEstates[3].Longitude = 50.0;

        //    ListOfRealEstates[4].Link = "sampleLink50";
        //    ListOfRealEstates[4].Area = 50;
        //    ListOfRealEstates[4].PricePerSqM = 50;
        //    ListOfRealEstates[4].NumberOfRooms = 50;
        //    ListOfRealEstates[4].Floor = "sampleFloor50";
        //    ListOfRealEstates[4].Price = 50;
        //    ListOfRealEstates[4].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[4].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[4].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[4].Street = "sampleStreet50";
        //    ListOfRealEstates[4].BuildYear = 50;
        //    ListOfRealEstates[4].Image = "sampleImage50";
        //    ListOfRealEstates[4].Latitude = 50.0;
        //    ListOfRealEstates[4].Longitude = 50.0;

        //    ListOfRealEstates[5].Link = "sampleLink50";
        //    ListOfRealEstates[5].Area = 50;
        //    ListOfRealEstates[5].PricePerSqM = 50;
        //    ListOfRealEstates[5].NumberOfRooms = 50;
        //    ListOfRealEstates[5].Floor = "sampleFloor50";
        //    ListOfRealEstates[5].Price = 50;
        //    ListOfRealEstates[5].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[5].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[5].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[5].Street = "sampleStreet50";
        //    ListOfRealEstates[5].BuildYear = 50;
        //    ListOfRealEstates[5].Image = "sampleImage50";
        //    ListOfRealEstates[5].Latitude = 50.0;
        //    ListOfRealEstates[5].Longitude = 50.0;

        //    ListOfRealEstates[6].Link = "sampleLink50";
        //    ListOfRealEstates[6].Area = 50;
        //    ListOfRealEstates[6].PricePerSqM = 50;
        //    ListOfRealEstates[6].NumberOfRooms = 50;
        //    ListOfRealEstates[6].Floor = "sampleFloor50";
        //    ListOfRealEstates[6].Price = 50;
        //    ListOfRealEstates[6].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[6].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[6].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[6].Street = "sampleStreet50";
        //    ListOfRealEstates[6].BuildYear = 50;
        //    ListOfRealEstates[6].Image = "sampleImage50";
        //    ListOfRealEstates[6].Latitude = 50.0;
        //    ListOfRealEstates[6].Longitude = 50.0;

        //    ListOfRealEstates[7].Link = "sampleLink50";
        //    ListOfRealEstates[7].Area = 50;
        //    ListOfRealEstates[7].PricePerSqM = 50;
        //    ListOfRealEstates[7].NumberOfRooms = 50;
        //    ListOfRealEstates[7].Floor = "sampleFloor50";
        //    ListOfRealEstates[7].Price = 50;
        //    ListOfRealEstates[7].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[7].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[7].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[7].Street = "sampleStreet50";
        //    ListOfRealEstates[7].BuildYear = 50;
        //    ListOfRealEstates[7].Image = "sampleImage50";
        //    ListOfRealEstates[7].Latitude = 50.0;
        //    ListOfRealEstates[7].Longitude = 50.0;

        //    ListOfRealEstates[8].Link = "sampleLink50";
        //    ListOfRealEstates[8].Area = 50;
        //    ListOfRealEstates[8].PricePerSqM = 50;
        //    ListOfRealEstates[8].NumberOfRooms = 50;
        //    ListOfRealEstates[8].Floor = "sampleFloor50";
        //    ListOfRealEstates[8].Price = 50;
        //    ListOfRealEstates[8].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[8].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[8].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[8].Street = "sampleStreet50";
        //    ListOfRealEstates[8].BuildYear = 50;
        //    ListOfRealEstates[8].Image = "sampleImage50";
        //    ListOfRealEstates[8].Latitude = 50.0;
        //    ListOfRealEstates[8].Longitude = 50.0;

        //    ListOfRealEstates[9].Link = "sampleLink50";
        //    ListOfRealEstates[9].Area = 50;
        //    ListOfRealEstates[9].PricePerSqM = 50;
        //    ListOfRealEstates[9].NumberOfRooms = 50;
        //    ListOfRealEstates[9].Floor = "sampleFloor50";
        //    ListOfRealEstates[9].Price = 50;
        //    ListOfRealEstates[9].MapLink = "sampleMapLink50";
        //    ListOfRealEstates[9].Municipality = "sampleMunicipality50";
        //    ListOfRealEstates[9].Microdistrict = "sampleMicrodistrict50";
        //    ListOfRealEstates[9].Street = "sampleStreet50";
        //    ListOfRealEstates[9].BuildYear = 50;
        //    ListOfRealEstates[9].Image = "sampleImage50";
        //    ListOfRealEstates[9].Latitude = 50.0;
        //    ListOfRealEstates[9].Longitude = 50.0;
    }
}
