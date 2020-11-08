using App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IRealEstate
    {
        Task<List<RealEstateModel>> GetRealEstates();
    }
}
