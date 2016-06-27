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
        // Навигационные свойства

        public virtual ICollection<Follower> StarUsers { get; set; }

        public virtual ICollection<Follower> FollowerUsers { get; set; }


        public virtual Profile Profile { get; set; }


        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<ReplyToComment> RepliesToComment { get; set; }

    }
}
