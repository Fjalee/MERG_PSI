
using Common;

namespace MERG_BackEnd
{
    class RealEstate : RealEstateModel
    {

        override
           public string ToString()
        {
            return $"\nKaina: {Price} €\nKaina/m²: {PricePerSqM} €/m²\nPlotas: {Area} m²\nMetai: {BuildYear}\nKambariai: {NumberOfRooms}\nSavivaldybė: {Municipality}\nMikrorajonas: {Microdistrict}\nGatvė: {Street}";
        }
    }
}