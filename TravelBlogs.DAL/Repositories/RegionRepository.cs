using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.DAL.Repositories
{
    public class RegionRepository : IRegionRepository
    {

        private readonly BlogContext _db;

        public RegionRepository(BlogContext context)
        {
            _db = context;
        }


         // Реализуем интерфейс

        public IEnumerable<Region> GetAll()
        {
            return _db.Regions;
        }

        public Region Get(int id)
        {
            return _db.Regions.Find(id);
        }

        public IQueryable<Region> Find(Expression<Func<Region, bool>> predicate)
        {
            return _db.Regions.Where(predicate);
        }

        public void Create(Region item)
        {
            _db.Regions.Add(item);
        }

        public void Update(Region item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Region region = _db.Regions.Find();
            if (region != null)
            {
                _db.Regions.Remove(region);
            }
        }

        public IQueryable<Region> GetRegions(int countryId)
        {
            return _db.Regions.Where(r => r.CountryId == countryId);
        }
    }
}
