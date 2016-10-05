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
    public class CommentRepository : ICommentRepository
    {

        private BlogContext db;


        // Реализуем интерфейс

        public CommentRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public IQueryable<Comment> Find(Expression<Func<Comment, Boolean>> predicate)
        {

            return db.Comments.Where(predicate);
        }

        public void Create(Comment comment)
        {
            db.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
            }
        }

     
        public IQueryable<Comment> GetRepliesToComment(int id)
        {
            return db.RepliesToComment.Where(c => c.MainCommentId == id)
                .Select(c=>c.RepliesToComment);
        }

        public IQueryable<Comment> GetCommentsByUser(string userId)
        {
            return db.Comments.Where(c => c.UserId == userId).Select(com => com);
        }

        public IQueryable<Comment> GetCommetsByPost(int postId)
        {
            return db.Comments.Where(c => c.PostId == postId).Select(com => com);
        }

        public void AddReplayToComment(ReplayToComment replayToComment)
        {
            db.RepliesToComment.Add(replayToComment);
        }
     
    }
}
