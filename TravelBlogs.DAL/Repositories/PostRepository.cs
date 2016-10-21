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

        public IQueryable<Post> GetAll(PagingInfo paging)
        {
            paging.TotalItems = _db.Posts.Count();
            return _db.Posts
                .OrderBy(p => p.Id)
                .Skip((paging.CurrentPage - 1)*paging.PageSize)
                .Take(paging.PageSize);
        }

        public Post Get(int id)
        {
            return _db.Posts.Find(id);
        }

        public IQueryable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            return _db.Posts.Where(predicate);
        }

        public IQueryable<Post> Find(Expression<Func<Post, bool>> predicate, PagingInfo paging)
        {
            paging.TotalItems = _db.Posts.Where(predicate).Count();
            return _db.Posts
                .Where(predicate)
                .OrderBy(p => p.Id)
                .Skip((paging.CurrentPage - 1)*paging.PageSize)
                .Take(paging.PageSize);
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
