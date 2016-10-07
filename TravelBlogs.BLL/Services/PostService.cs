using System;
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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _db;

        public PostService(IUnitOfWork uow)
        {
            this._db = uow;
        }




        public IEnumerable<PostDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.GetAll());
        }

        public IEnumerable<PostDTO> Find(Func<PostDTO, Boolean> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Post, Boolean>>>(predicateDto);
            return Mapper.Map<IQueryable<Post>, IEnumerable<PostDTO>>(_db.Posts.Find(predicate));
        }

        public IEnumerable<PostDTO> GetPostsByUser(string userId)
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(_db.Posts.GetPostsByUser(userId));
        }

        public PostDTO Get(int id)
        {
            return Mapper.Map<Post, PostDTO>(_db.Posts.Get(id));
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
