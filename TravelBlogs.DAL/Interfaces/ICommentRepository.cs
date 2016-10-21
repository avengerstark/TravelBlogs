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
        IQueryable<Comment> GetRepliesToComment(int id);
        void AddReplayToComment(ReplayToComment replayToComment);
        void DeleteReplayToComment(ReplayToComment replayToComment);
    }
}
