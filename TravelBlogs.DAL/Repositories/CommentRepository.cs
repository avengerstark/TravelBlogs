using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Interfaces;


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

        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return db.Comments.Where(predicate).ToList();
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




     
        public IEnumerable<Comment> GetRepliesToComment(int id)
        {
            return db.RepliesToComment.Where(c => c.MainCommentId == id)
                .Select(c=>c.RepliesToComment);
        }

        public IEnumerable<Comment> GetCommentsByUser(string userId)
        {
            return db.Comments.Where(c => c.UserId == userId).ToList();
        }
    }
}
