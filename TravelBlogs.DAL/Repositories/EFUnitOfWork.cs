using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelBlogs.DAL.EF;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.DAL.Identity;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _db;
        private CommentRepository _commentRepository;
        private CountryRepository _countryRepository;
        private PlaceRepository _placeRepository;
        private PostRepository _postRepository;
        private ProfileRepository _profileRepository;
        private RegionRepository _regionRepository;
        private FollowerRepository _followerRepository;


        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public EFUnitOfWork(string connectionString)
        {
            _db = new BlogContext(connectionString);
        }


        public ICommentRepository Comments
        {
            get { return _commentRepository ?? (_commentRepository = new CommentRepository(_db)); }
        }

        public ICountryRepository Countries
        {
            get { return _countryRepository ?? (_countryRepository = new CountryRepository(_db)); }
        }

        public IPlaceRepository Places
        {
            get { return _placeRepository ?? (_placeRepository = new PlaceRepository(_db)); }
        }

        public IPostRepository Posts
        {
            get { return _postRepository ?? (_postRepository = new PostRepository(_db)); }
        }

        public IProfileRepository Profiles
        {
            get { return _profileRepository ?? (_profileRepository = new ProfileRepository(_db)); }
        }

        public IRegionRepository Regions
        {
            get { return _regionRepository ?? (_regionRepository = new RegionRepository(_db)); }
        }



        public IFollowerRepository Followers
        {
            get { return _followerRepository ?? (_followerRepository = new FollowerRepository(_db)); }
        }


        public ApplicationUserManager UserManager
        {
            get {
                return _userManager ?? (_userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db)));
            }

        }

        public ApplicationRoleManager RoleManager
        {
            get {
                return _roleManager ?? (_roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db)));
            }
        }


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }
   
    }
}
