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
    public class PostService : IPostService
    {
        private IUnitOfWork db;

        public PostService(IUnitOfWork uow)
        {
            this.db = uow;
        }

        public IEnumerable<PostDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTO> Find(Func<PostDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTO> GetPostsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public PostDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(PostDTO post)
        {
            throw new NotImplementedException();
        }

        public void Update(PostDTO post)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Evaluate(VoteDTO vote)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvaluate(VoteDTO vote)
        {
            throw new NotImplementedException();
        }
    }
}
