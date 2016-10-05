using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;
using System.Linq.Expressions;

namespace TravelBlogs.DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private BlogContext db;


        public CountryRepository(BlogContext context)
        {
            this.db = context;
        }


        // Реализуем методы интерфейса
        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }

        public Country Get(int id)
        {
            return db.Countries.Find(id);
        }

        public IQueryable<Country> Find(Expression<Func<Country, Boolean>> predicate)
        {
            return db.Countries.Where(predicate).Select(c=>c);
        }

        public void Create(Country country)
        {
            db.Countries.Add(country);
        }

        public void Update(Country country)
        {
            db.Entry(country).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
            {
                db.Countries.Remove(country);
            }
        }
  
    }
}
