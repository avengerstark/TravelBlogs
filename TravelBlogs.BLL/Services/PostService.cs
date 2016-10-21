using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Infrastructure;

namespace TravelBlogs.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _db;
        private readonly ICacheService _cacheService;
        public PostService(IUnitOfWork uow)
        {
            _db = uow;
            _cacheService = new InMemoryCache();
        }




        public IEnumerable<PostDTO> GetAll()
        {
            return _cacheService.GetOrSet("GetAllPosts",
                () => Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.GetAll()));
        }

        public IEnumerable<PostDTO> GetAll(PagingInfoDTO pagingInfoDto)
        {
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(String.Format("GetAllPosts{0}{1}", pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IQueryable<Post>, IEnumerable<PostDTO>>(_db.Posts.GetAll(pagingInfo)));
        }

        public IEnumerable<PostDTO> Find(Expression<Func<PostDTO, Boolean>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Post, Boolean>>>(predicateDto);
            return _cacheService.GetOrSet(String.Format("FindPosts{0}", predicate),
                () => Mapper.Map<IQueryable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate)));
        }

        public IEnumerable<PostDTO> Find(Expression<Func<PostDTO, bool>> predicateDto, PagingInfoDTO pagingInfoDto)
        {
            var predicate = Mapper.Map<Expression<Func<Post, Boolean>>>(predicateDto);
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("FindPosts{0}{1}{2}", pagingInfo.CurrentPage, pagingInfo.PageSize, predicate),
                () => Mapper.Map<IQueryable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate, pagingInfo)));
        }

        public IEnumerable<PostDTO> GetPostsByUser(string userId)
        {
            Expression<Func<Post, bool>> predicate = post => post.UserId == userId;
            return _cacheService.GetOrSet(String.Format("GetPostsByUser{0}", userId),
                () => Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate)));
        }

        public IEnumerable<PostDTO> GetPostsByUser(string userId, PagingInfoDTO pagingInfoDto)
        {
            Expression<Func<Post, bool>> predicate = post => post.UserId == userId;
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("GetPostsByUser{0}{1}{2}", userId, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate, pagingInfo)));
        }

        public IEnumerable<PostDTO> GetPostsByPlace(int placeId)
        {
            Expression<Func<Post, bool>> predicate = post => post.PlaceId == placeId;
            return _cacheService.GetOrSet(String.Format("GetPostsByPlace{0}", placeId),
                () => Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate)));
        }

        public IEnumerable<PostDTO> GetPostsByPlace(int placeId, PagingInfoDTO pagingInfoDto)
        {
            Expression<Func<Post, bool>> predicate = post => post.PlaceId == placeId;
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("GetPostsByPlace{0}{1}{2}", placeId, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate, pagingInfo)));
        }


        public PostDTO Get(int id)
        {
            return _cacheService.GetOrSet(String.Format("GetPost+{0}", id),
                () => Mapper.Map<Post, PostDTO>(_db.Posts.Get(id)));
        }

        public void Create(PostDTO postDto)
        {
            Post post = Mapper.Map<PostDTO, Post>(postDto);
            _db.Posts.Create(post);
        }

        public void Update(PostDTO postDto)
        {
            Post post = Mapper.Map<PostDTO, Post>(postDto);
            _db.Posts.Update(post);
        }

        public void Delete(int id)
        {
            _db.Posts.Delete(id);
        }

        public void Evaluate(VoteDTO voteDto)
        {
            Vote vote = Mapper.Map<VoteDTO, Vote>(voteDto);
            _db.Posts.Evaluate(vote);
        }

        public void DeleteEvaluate(VoteDTO voteDto)
        {
            Vote vote = Mapper.Map<VoteDTO, Vote>(voteDto);
            _db.Posts.DeleteEvaluate(vote);
        }
   
    }
}
