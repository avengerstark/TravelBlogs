using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;
using System.Linq.Expressions;
using TravelBlogs.DAL.Infrastructure;


namespace TravelBlogs.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly BlogContext _db;


        // Реализуем интерфейс

        public CommentRepository(BlogContext context)
        {
            this._db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comments;
        }

        public IQueryable<Comment> GetAll(PagingInfo paging)
        {
            paging.TotalItems = _db.Comments.Count();
            return _db.Comments
                .OrderBy(c => c.Id)
                .Skip((paging.CurrentPage - 1)*paging.PageSize)
                .Take(paging.PageSize);
        }

        public Comment Get(int id)
        {
            return _db.Comments.Find(id);
        }

        public IQueryable<Comment> Find(Expression<Func<Comment, Boolean>> predicate)
        {

            return _db.Comments.Where(predicate);
        }

        public IQueryable<Comment> Find(Expression<Func<Comment, bool>> predicate, PagingInfo paging)
        {
            paging.TotalItems = _db.Comments.Where(predicate).Count();
            return _db.Comments
                .Where(predicate)
                .OrderBy(c => c.Id)
                .Skip((paging.CurrentPage - 1)*paging.PageSize)
                .Take(paging.PageSize);
        }

        public void Create(Comment comment)
        {
            _db.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            _db.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Comment comment = _db.Comments.Find(id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
            }
        }

     
        public IQueryable<Comment> GetRepliesToComment(int id)
        {
            return _db.RepliesToComment.Where(c => c.MainCommentId == id)
                .Select(c=>c.RepliesToComment);
        }

        public IQueryable<Comment> GetCommentsByUser(string userId)
        {
            return _db.Comments.Where(c => c.UserId == userId).Select(com => com);
        }

        public IQueryable<Comment> GetCommetsByPost(int postId)
        {
            return _db.Comments.Where(c => c.PostId == postId).Select(com => com);
        }

        public void AddReplayToComment(ReplayToComment replayToComment)
        {
            _db.RepliesToComment.Add(replayToComment);
        }
    }
}
