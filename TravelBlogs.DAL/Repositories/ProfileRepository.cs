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
    public class ProfileRepository : IProfileRepository
    {

        private BlogContext db;

        public ProfileRepository(BlogContext context)
        {
            db = context;
        }

        // Реализуем интерфейс

        public IEnumerable<Profile> GetAll()
        {
            return db.Profiles;
        }

        public Profile Get(int id)
        {
            return db.Profiles.Find(id);
        }

        public IQueryable<Profile> Find(Expression<Func<Profile, bool>> predicate)
        {
            return db.Profiles.Where(predicate);
        }

        public void Create(Profile item)
        {
            db.Profiles.Add(item);
        }

        public void Update(Profile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile != null)
            {
                db.Profiles.Remove(profile);
            }
        }


        public Profile GetProfileByUser(string userId)
        {
            return db.Profiles.Where(p => p.UserId == userId).FirstOrDefault();
        }

    }
}
