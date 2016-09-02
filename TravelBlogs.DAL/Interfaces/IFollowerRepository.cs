using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.DAL.Interfaces
{
    public interface IFollowerRepository
    {
        void Create(Follower follower);

        void Delete(Follower follower);

        IEnumerable<ApplicationUser> GetFollowersByUser(string userId);
    }
}
