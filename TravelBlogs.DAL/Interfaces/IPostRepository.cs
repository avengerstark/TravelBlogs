using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.DAL.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsByUser(string userId);

        void RatePost(int postId, string userId, bool isLike);
    }
}
