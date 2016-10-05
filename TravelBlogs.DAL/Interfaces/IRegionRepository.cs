using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.DAL.Interfaces
{
    public interface IRegionRepository : IRepository<Region>
    {
        IQueryable<Region> GetRegions(int countryId);
        
    }
}
