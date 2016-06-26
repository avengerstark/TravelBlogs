using TravelBlogs.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelBlogs.DAL.EF
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext(string connectionString) : base(connectionString) { }





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
