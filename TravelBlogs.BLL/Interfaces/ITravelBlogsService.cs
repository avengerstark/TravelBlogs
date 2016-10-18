using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.Interfaces
{
    public interface ITravelBlogsService 
    {
        ICommentService Comments { get; }
        ILocationService Locations { get; }
        IPostService Posts { get; }
        IUserService Users { get; }

        void Dispose();
        void SaveChanges();
    }
}
