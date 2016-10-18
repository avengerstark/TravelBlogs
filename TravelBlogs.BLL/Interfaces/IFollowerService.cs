using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;

namespace TravelBlogs.BLL.Interfaces
{
    public interface IFollowerService
    {
        void Create(FollowerDTO followerDto);

        void Delete(FollowerDTO followerDto);

        IEnumerable<UserDTO> GetFollowersByUser(string userId);

        IEnumerable<UserDTO> GetUserSubscriptions(string userId);


    }
}
