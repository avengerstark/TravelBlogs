using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Identity;

namespace TravelBlogs.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICommentRepository Comments { get; }
        ICountryRepository Countries { get; }   
        IPlaceRepository Places { get; }
        IPostRepository Posts { get; }
        IProfileRepository Profiles { get; }
        IRegionRepository Regions { get; }
        IFollowerRepository Followers { get; }

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        Task SaveAsync();
    }
}
