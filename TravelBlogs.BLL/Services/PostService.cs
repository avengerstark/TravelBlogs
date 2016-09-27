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
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(db.Posts.GetAll());
        }

        public IEnumerable<PostDTO> Find(Func<PostDTO, Boolean> predicateDto)
        {
            Func<Post, Boolean> predicate = Mapper.Map<Func<PostDTO, Boolean>, Func<Post, Boolean>>(predicateDto);
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(db.Posts.Find(predicate));           
        }

        public IEnumerable<PostDTO> GetPostsByUser(string userId)
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(db.Posts.GetPostsByUser(userId));
        }

        public PostDTO Get(int id)
        {
            return Mapper.Map<Post, PostDTO>(db.Posts.Get(id));
        }

        public void Create(PostDTO postDto)
        {
            Post post = Mapper.Map<PostDTO, Post>(postDto);
            db.Posts.Create(post);
        }

        public void Update(PostDTO postDto)
        {
            Post post = Mapper.Map<PostDTO, Post>(postDto);
            db.Posts.Update(post);
        }

        public void Delete(int id)
        {
            db.Posts.Delete(id);
        }

        public void Evaluate(VoteDTO voteDto)
        {
            Vote vote = Mapper.Map<VoteDTO, Vote>(voteDto);
            db.Posts.Evaluate(vote);
        }

        public void DeleteEvaluate(VoteDTO voteDto)
        {
            Vote vote = Mapper.Map<VoteDTO, Vote>(voteDto);
            db.Posts.DeleteEvaluate(vote);
        }
    }
}
