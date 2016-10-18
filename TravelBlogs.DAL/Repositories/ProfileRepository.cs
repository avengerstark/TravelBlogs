using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Infrastructure;
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

        public IQueryable<Profile> GetAll(PagingInfo paging)
        {
            paging.TotalItems = _db.Profiles.Count();
            return _db.Profiles
                .OrderBy(p => p.Id)
                .Skip((paging.CurrentPage - 1)*paging.PageSize)
                .Take(paging.PageSize);
        }

        public Profile Get(int id)
        {
            return _db.Profiles.Find(id);
        }

        public IQueryable<Profile> Find(Expression<Func<Profile, bool>> predicate)
        {
            return _db.Profiles.Where(predicate);
        }

        public IQueryable<Profile> Find(Expression<Func<Profile, bool>> predicate, PagingInfo paging)
        {
            paging.TotalItems = _db.Profiles.Where(predicate).Count();
            return _db.Profiles
                .Where(predicate)
                .OrderBy(p => p.Id)
                .Skip((paging.CurrentPage - 1)*paging.PageSize)
                .Take(paging.PageSize);
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
            return _db.Profiles.FirstOrDefault(p => p.UserId == userId);
        }
    }
}
