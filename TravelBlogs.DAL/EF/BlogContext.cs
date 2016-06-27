using TravelBlogs.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TravelBlogs.DAL.EF
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext(string connectionString) : base(connectionString) { }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Follower> Followers { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<ReplyToComment> RepliesToComments { get; set; }

        public DbSet<Vote> Votes { get; set; }



        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            
            // Составной ключ таблицы Follower
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
