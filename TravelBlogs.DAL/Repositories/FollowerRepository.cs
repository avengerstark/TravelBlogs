using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.DAL.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly BlogContext _db;

        public FollowerRepository(BlogContext context)
        {
            this._db = context;
        }

        public void Create(Follower follower)
        {
            _db.Followers.Add(follower);
        }

        public void Delete(Follower follower)
        {
            _db.Followers.Remove(follower);
        }

        public IQueryable<ApplicationUser> GetFollowersByUser(string userId)
        {
            return _db.Followers.Where(f => f.StarUserId == userId).
                                Select(f => f.FollowerUser);
        }
    }
}
