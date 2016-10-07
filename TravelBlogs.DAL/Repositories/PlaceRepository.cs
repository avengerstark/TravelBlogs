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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly BlogContext _db;

        public PlaceRepository(BlogContext context)
        {
            _db = context;
        }


        // Реализуем интерфейс

        public IEnumerable<Place> GetAll()
        {
            return _db.Places;
        }

        public Place Get(int id)
        {
            return _db.Places.Find(id);
        }

        public IQueryable<Place> Find(Expression<Func<Place, bool>> predicate)
        {
            return _db.Places.Where(predicate);
        }

        public void Create(Place item)
        {
            _db.Places.Add(item);
        }

        public void Update(Place item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Place place = _db.Places.Find(id);
            if (place != null)
            {
                _db.Places.Remove(place);
            }
        }


        public IQueryable<Place> GetPlaces(int regionId)
        {
            return _db.Places.Where(p => p.RegionId == regionId);
        }
   
    }
}
