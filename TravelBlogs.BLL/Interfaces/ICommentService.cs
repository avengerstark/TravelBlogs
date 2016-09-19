using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.DTO;

namespace TravelBlogs.BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetAll();
        IEnumerable<CommentDTO> GetCommetsByPost(int postId);  
        IEnumerable<CommentDTO> Find(Func<CommentDTO, Boolean> predicate);
        IEnumerable<CommentDTO> GetRepliesToComment(int commentId);
        IEnumerable<CommentDTO> GetCommentsByUser(string userId);
        CommentDTO Get(int id);
        void Create(CommentDTO comment);
        void Update(CommentDTO comment);
        void Delete(int id);
        void AddReplayToComment(ReplayToCommentDTO replayToComment);

    }
}
