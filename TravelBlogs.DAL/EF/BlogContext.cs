using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TravelBlogs.DAL.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelBlogs.DAL.EF
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            // Составной ключ
            modelBuilder.Entity<Follower>().HasKey(f => new { f.StarUserId, f.FollowerUserId });


            // Отключаем каскадное удаление у таблиц ApplicationUser - Follower
            modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.StarUsers)
            .WithRequired(u => u.StarUser)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.FollowerUsers)
            .WithRequired(u => u.FollowerUser)
            .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
