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
    public class PostRepository : IPostRepository
    {

        private readonly BlogContext _db;

        public PostRepository(BlogContext context)
        {
            _db = context;
        }

        // Реализуем интерфейс

        public IEnumerable<Post> GetAll()
        {
            return _db.Posts;
        }

        public Post Get(int id)
        {
            return _db.Posts.Find(id);
        }

        public IQueryable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            return _db.Posts.Where(predicate);
        }

        public void Create(Post item)
        {
            _db.Posts.Add(item);
        }

        public void Update(Post item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Post post = _db.Posts.Find(id);
            if (post != null)
            {
                _db.Posts.Remove(post);
            }
        }




        public IQueryable<Post> GetPostsByUser(string id)
        {
            return _db.Posts.Where(p => p.UserId == id);
        }



        public void Evaluate(Vote vote)
        {
            _db.Votes.Add(vote);
        }



        public void DeleteEvaluate(Vote vote)
        {
            _db.Votes.Remove(vote);
        }


    }
}
