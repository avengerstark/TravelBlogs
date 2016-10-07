﻿using System;
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

        private readonly BlogContext _db;

        public ProfileRepository(BlogContext context)
        {
            _db = context;
        }

        // Реализуем интерфейс

        public IEnumerable<Profile> GetAll()
        {
            return _db.Profiles;
        }

        public Profile Get(int id)
        {
            return _db.Profiles.Find(id);
        }

        public IQueryable<Profile> Find(Expression<Func<Profile, bool>> predicate)
        {
            return _db.Profiles.Where(predicate);
        }

        public void Create(Profile item)
        {
            _db.Profiles.Add(item);
        }

        public void Update(Profile item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Profile profile = _db.Profiles.Find(id);
            if (profile != null)
            {
                _db.Profiles.Remove(profile);
            }
        }


        public Profile GetProfileByUser(string userId)
        {
            return _db.Profiles.Where(p => p.UserId == userId).FirstOrDefault();
        }

    }
}
