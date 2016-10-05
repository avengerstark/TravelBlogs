﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork db;

        public CommentService(IUnitOfWork uow)
        {
            this.db = uow;
        }




        public IEnumerable<CommentDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(db.Comments.GetAll());
        }

        public IEnumerable<CommentDTO> GetCommetsByPost(int postId)
        {
            return Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(db.Comments.GetCommetsByPost(postId));
        }


        public IEnumerable<CommentDTO> GetRepliesToComment(int commentId)
        {
            return Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(db.Comments.GetRepliesToComment(commentId));
        }

        public IEnumerable<CommentDTO> GetCommentsByUser(string userId)
        {
            return Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(db.Comments.GetCommentsByUser(userId));
        }

        public CommentDTO Get(int id)
        {
            return Mapper.Map<Comment, CommentDTO>(db.Comments.Get(id));
        }

        public void Create(CommentDTO commentDto)
        {
            Comment comment = Mapper.Map<CommentDTO, Comment>(commentDto);
            db.Comments.Create(comment);
        }

        public void Update(CommentDTO commentDto)
        {
            Comment comment = Mapper.Map<CommentDTO, Comment>(commentDto);
            db.Comments.Update(comment);
        }

        public void Delete(int id)
        {
            db.Comments.Delete(id);
        }

        public void AddReplayToComment(ReplayToCommentDTO replayToCommentDto)
        {
            ReplayToComment replayToComment = Mapper.Map<ReplayToCommentDTO, ReplayToComment>(replayToCommentDto);
            db.Comments.AddReplayToComment(replayToComment);        
        }



        public IEnumerable<CommentDTO> Find(Expression<Func<CommentDTO, bool>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Comment, Boolean>>>(predicateDto);
            return Mapper.Map<IQueryable<Comment>, IEnumerable<CommentDTO>>(db.Comments.Find(predicate));
        }
    }
}
