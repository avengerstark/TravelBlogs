using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.BLL.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IUnitOfWork _db;
        private readonly ICacheService _cacheService;
        public FollowerService(IUnitOfWork uow)
        {
            _db = uow;
            _cacheService = new InMemoryCache();
        }


        public void Create(FollowerDTO followerDto)
        {
            Follower follower = Mapper.Map<Follower>(followerDto);
            _db.Followers.Create(follower);
        }

        public void Delete(FollowerDTO followerDto)
        {
            Follower follower = Mapper.Map<Follower>(followerDto);
            _db.Followers.Delete(follower);
        }

        public IEnumerable<UserDTO> GetFollowersByUser(string userId)
        {
            return _cacheService.GetOrSet(String.Format("GetFollowersByUser{0}", userId),
                () =>
                    Mapper.Map<IQueryable<ApplicationUser>, IEnumerable<UserDTO>>(
                        _db.Followers.GetFollowersByUser(userId)));
        }

        public IEnumerable<UserDTO> GetUserSubscriptions(string userId)
        {
            return _cacheService.GetOrSet(String.Format("GetUserSubscriptions{0}", userId),
                () =>
                    Mapper.Map<IQueryable<ApplicationUser>, IEnumerable<UserDTO>>(
                        _db.Followers.GetUserSubscriptions(userId)));
        }
    }
}
