using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> Find(Func<CommentDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetRepliesToComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetCommentsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public CommentDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(CommentDTO comment)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentDTO comment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void AddReplayToComment(ReplayToCommentDTO replayToComment)
        {
            throw new NotImplementedException();
        }
    }
}
