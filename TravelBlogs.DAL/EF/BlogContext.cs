using TravelBlogs.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Runtime.CompilerServices;

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

        public DbSet<ReplayToComment> RepliesToComment { get; set; }

        public DbSet<Vote> Votes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            // Составной ключ таблицы Follower
            modelBuilder.Entity<Follower>().HasKey(f => new { f.StarUserId, f.FollowerUserId });
            // Составной ключ таблицы Vote
            modelBuilder.Entity<Vote>().HasKey(v => new {v.PostId, v.UserId });
            // Составной ключ таблицы ReplayToComment
            modelBuilder.Entity<ReplayToComment>().HasKey(r => new { r.MainCommentId, r.ReplayToCommentId});


            // Отключаем каскадное удаление у таблиц ApplicationUser - Follower
            modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.StarUsers)
            .WithRequired(u => u.StarUser)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.FollowerUsers)
            .WithRequired(u => u.FollowerUser)
            .WillCascadeOnDelete(false);



            // Отключаем каскадное удаление у таблиц Comment - ReplayToComment
            modelBuilder.Entity<Comment>()
           .HasMany(u => u.MainComments)
           .WithRequired(u => u.MainComments)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
            .HasMany(u => u.RepliesToComment)
            .WithRequired(u => u.RepliesToComment)  
            .WillCascadeOnDelete(false);


            // Отключаем каскадное удаление у таблиц Vote - Post
            modelBuilder.Entity<Post>()
                .HasMany(p=>p.Votes)
                .WithRequired(v=>v.Post)
                .WillCascadeOnDelete(false);

            // Отключаем каскадное удаление у таблиц ApplicationUser - Post
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u=>u.Votes)
                .WithRequired(v=>v.ApplicationUser)
                .WillCascadeOnDelete(false);




            modelBuilder.Entity<Post>()
                .HasOptional(p => p.ApplicationUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(post => post.UserId);

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(u=>u.Posts)
            //    .WithRequired(p=>p.ApplicationUser)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
