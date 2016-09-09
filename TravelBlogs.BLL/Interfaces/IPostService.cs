using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.DTO;

namespace TravelBlogs.BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetAll();
        IEnumerable<PostDTO> Find(Func<PostDTO, Boolean> predicate);
        IEnumerable<PostDTO> GetPostsByUser(string userId);
        PostDTO Get(int id);
        void Create(PostDTO post);
        void Update(PostDTO post);
        void Delete(int id);
        void Evaluate(VoteDTO vote);
        void DeleteEvaluate(VoteDTO vote);
    }
}
