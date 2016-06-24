using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;


namespace TravelBlogs.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Follower> StarUsers { get; set; }

        public virtual ICollection<Follower> FollowerUsers { get; set; }
    }
}
