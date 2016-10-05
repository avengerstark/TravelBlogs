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

        private BlogContext db;

        public PostRepository(BlogContext context)
        {
            db = context;
        }

        // Реализуем интерфейс

        public IEnumerable<Post> GetAll()
        {
            return db.Posts;
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public IQueryable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            return db.Posts.Where(predicate);
        }

        public void Create(Post item)
        {
            db.Posts.Add(item);
        }

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
            {
                db.Posts.Remove(post);
            }
        }




        public IQueryable<Post> GetPostsByUser(string id)
        {
            return db.Posts.Where(p => p.UserId == id);
        }



        public void Evaluate(Vote vote)
        {
            db.Votes.Add(vote);
        }



        public void DeleteEvaluate(Vote vote)
        {
            db.Votes.Remove(vote);
        }
    }
}
