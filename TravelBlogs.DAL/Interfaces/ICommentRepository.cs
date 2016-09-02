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
        void AddReplayToComment(ReplyToComment replayToComment);

        IEnumerable<Comment> GetRepliesToComment(int commentId);

                

        IEnumerable<Comment> GetCommentsByUser(string userId);

    }
}
