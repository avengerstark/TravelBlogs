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
        private BlogContext _db;
        private CommentRepository _commentRepository;
        private CountryRepository _countryRepository;
        private PlaceRepository _placeRepository;
        private PostRepository _postRepository;
        private ProfileRepository _profileRepository;
        private RegionRepository _regionRepository;


        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public EFUnitOfWork(string connectionString)
        {
            _db = new BlogContext(connectionString);
        }


        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_db);
                return _commentRepository;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new CountryRepository(_db);
                return _countryRepository;
            }
        }

        public IPlaceRepository Places
        {
            get
            {
                if (_placeRepository == null)
                    _placeRepository = new PlaceRepository(_db);
                return _placeRepository;
            }
        }

        public IPostRepository Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_db);
                return _postRepository;
            }
        }

        public IProfileRepository Profiles
        {
            get
            {
                if (_profileRepository == null)
                    _profileRepository = new ProfileRepository(_db);
                return _profileRepository;
            }
        }

        public IRegionRepository Regions
        {
            get
            {
                if (_regionRepository == null)
                    _regionRepository = new RegionRepository(_db);
                return _regionRepository;
            }
        }




        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
                return _userManager;
            }

        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (_roleManager == null)
                    _roleManager = new ApplicationRoleManager( new RoleStore<ApplicationRole>(_db));
                return _roleManager;
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
