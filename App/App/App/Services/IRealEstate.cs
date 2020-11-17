using App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IRealEstate
    {
        Task<List<RealEstateModel>> GetRealEstates();
    }
}
