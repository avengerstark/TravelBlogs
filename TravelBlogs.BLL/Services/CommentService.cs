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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _db;
        private readonly ICacheService _cacheService;
        public CommentService(IUnitOfWork uow)
        {
            _db = uow;
            _cacheService = new InMemoryCache();
        }




        public IEnumerable<CommentDTO> GetAll()
        {
            return _cacheService.GetOrSet("GetAllComments",
                () => Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.GetAll()));
        }

        public IEnumerable<CommentDTO> GetAll(PagingInfoDTO pagingInfoDto)
        {
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(String.Format("GetAllComments{0}{1}", pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.GetAll(pagingInfo)));
        }

        public IEnumerable<CommentDTO> Find(Expression<Func<CommentDTO, bool>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Comment, Boolean>>>(predicateDto);
            return _cacheService.GetOrSet(String.Format("FindComments{0}", predicate),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.Find(predicate)));
        }

        public IEnumerable<CommentDTO> Find(Expression<Func<CommentDTO, bool>> predicateDto, PagingInfoDTO pagingInfoDto)
        {
            var predicate = Mapper.Map<Expression<Func<Comment, Boolean>>>(predicateDto);
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("FindComments{0}{1}{2}", pagingInfo.CurrentPage, pagingInfo.PageSize, predicate),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.Find(predicate, pagingInfo)));
        }

        public IEnumerable<CommentDTO> GetRepliesToComment(int commentId)
        {
            return _cacheService.GetOrSet(String.Format("GetRepliesToComment{0}", commentId),
                () =>
                    Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(
                        _db.Comments.GetRepliesToComment(commentId)));
        }

        public IEnumerable<CommentDTO> GetCommetsByPost(int postId)
        {
            Expression<Func<Comment, bool>> predicate = comment => comment.PostId == postId;
            return _cacheService.GetOrSet(String.Format("GetCommetsByPost{0}", postId),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.Find(predicate)));
        }


        public IEnumerable<CommentDTO> GetCommetsByPost(int postId, PagingInfoDTO pagingInfoDto)
        {
            Expression<Func<Comment, bool>> predicate = comment => comment.PostId == postId;
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("GetCommetsByPost{0}{1}{2}", postId, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.Find(predicate, pagingInfo)));
        }

        public IEnumerable<CommentDTO> GetCommentsByUser(string userId)
        {
            Expression<Func<Comment, bool>> predicate = comment => comment.UserId == userId;
            return _cacheService.GetOrSet(String.Format("GetCommentsByUser{0}", userId),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.Find(predicate)));
        }

        public IEnumerable<CommentDTO> GetCommentsByUser(string userId, PagingInfoDTO pagingInfoDto)
        {
            Expression<Func<Comment, bool>> predicate = comment => comment.UserId == userId;
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("GetCommentsByUser{0}{1}{2}", userId, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(_db.Comments.Find(predicate, pagingInfo)));
        }

        public CommentDTO Get(int id)
        {
            return _cacheService.GetOrSet(String.Format("GetComment{0}", id),
                () => Mapper.Map<Comment, CommentDTO>(_db.Comments.Get(id)));
        }

        public void Create(CommentDTO commentDto)
        {
            Comment comment = Mapper.Map<CommentDTO, Comment>(commentDto);
            _db.Comments.Create(comment);
        }

        public void Update(CommentDTO commentDto)
        {
            Comment comment = Mapper.Map<CommentDTO, Comment>(commentDto);
            _db.Comments.Update(comment);
        }

        public void Delete(int id)
        {
            _db.Comments.Delete(id);
        }

        public void AddReplayToComment(ReplayToCommentDTO replayToCommentDto)
        {
            ReplayToComment replayToComment = Mapper.Map<ReplayToCommentDTO, ReplayToComment>(replayToCommentDto);
            _db.Comments.AddReplayToComment(replayToComment);        
        }

        public void DeleteReplayToComment(ReplayToCommentDTO replayToCommentDto)
        {
            ReplayToComment replayToComment = Mapper.Map<ReplayToCommentDTO, ReplayToComment>(replayToCommentDto);
            _db.Comments.DeleteReplayToComment(replayToComment);
        }
    }
}
