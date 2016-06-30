using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Post> Find(Func<Post, bool> predicate)
        {
            return db.Posts.Where(predicate).ToList();
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




        public IEnumerable<Post> GetPostsByUser(string id)
        {
            return db.Posts.Where(p => p.UserId == id).ToList();
        }

        public void RatePost(int postId, string userId, bool isLike)
        {
            Vote vote = new Vote { UserId=userId, PostId = postId, IsLike=isLike };

            db.Votes.Add(vote);
        }
            
    }
}
