using TravelBlogs.DAL.Entities;
using Microsoft.AspNet.Identity;
using TravelBlogs.DAL.EF;

namespace TravelBlogs.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }

    }
}
