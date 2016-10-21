using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;

namespace TravelBlogs.BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetAll();
        IEnumerable<PostDTO> GetAll(PagingInfoDTO pagingInfo); 
        IEnumerable<PostDTO> Find(Expression<Func<PostDTO, Boolean>> predicate, PagingInfoDTO pagingInfoDto);
        IEnumerable<PostDTO> Find(Expression<Func<PostDTO, Boolean>> predicate);
        IEnumerable<PostDTO> GetPostsByUser(string userId);
        IEnumerable<PostDTO> GetPostsByUser(string userId, PagingInfoDTO pagingInfoDto);
        IEnumerable<PostDTO> GetPostsByPlace(int placeId);
        IEnumerable<PostDTO> GetPostsByPlace(int placeId, PagingInfoDTO pagingInfoDto); 
        PostDTO Get(int id);
        void Create(PostDTO post);
        void Update(PostDTO post);
        void Delete(int id);
        void Evaluate(VoteDTO vote);
        void DeleteEvaluate(VoteDTO vote);
    }
}
