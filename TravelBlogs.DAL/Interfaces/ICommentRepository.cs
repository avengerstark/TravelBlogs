using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.DAL.Entities;


namespace TravelBlogs.DAL.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void AddReplayToComment(ReplayToComment replayToComment);

        IQueryable<Comment> GetRepliesToComment(int commentId);

        IQueryable<Comment> GetCommetsByPost(int postId);        

        IQueryable<Comment> GetCommentsByUser(string userId);

    }
}
