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

        IEnumerable<Comment> GetRepliesToComment(int commentId);

        IEnumerable<Comment> GetCommetsByPost(int postId);        

        IEnumerable<Comment> GetCommentsByUser(string userId);

    }
}
