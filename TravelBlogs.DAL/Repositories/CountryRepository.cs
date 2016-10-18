using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.DAL.Infrastructure;
using System.Linq.Expressions;

namespace TravelBlogs.DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BlogContext _db;


        public CountryRepository(BlogContext context)
        {
            _db = context;
        }


        // Реализуем методы интерфейса
        public IEnumerable<Country> GetAll()
        {
            return _db.Countries;
        }

        public Country Get(int id)
        {
            return _db.Countries.Find(id);
        }

        public IQueryable<Country> Find(Expression<Func<Country, Boolean>> predicate)
        {
            return _db.Countries.Where(predicate).Select(c=>c);
        }

        public void Create(Country country)
        {
            _db.Countries.Add(country);
        }

        public void Update(Country country)
        {
            _db.Entry(country).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Country country = _db.Countries.Find(id);
            if (country != null)
            {
                _db.Countries.Remove(country);
            }
        }



        public IQueryable<Country> Find(Expression<Func<Country, bool>> predicate, PagingInfo paging)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Country> GetAll(PagingInfo paging)
        {
            throw new NotImplementedException();
        }
    }
}
