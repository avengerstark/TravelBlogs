using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Comment> Comments { get; }
        IRepository<Country> Countries { get; }
        IRepository<Follower> Followers { get; }
        IRepository<Place> Places { get; }
        IRepository<Post> Posts { get; }
        IRepository<Profile> Profiles { get; }
        IRepository<Region> Regions { get; }
        IRepository<ReplyToComment> RepliesToComment { get; }
        IRepository<Vote> Votes { get; }
        void Save();
    }
}
