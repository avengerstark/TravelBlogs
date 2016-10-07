using System;

namespace TravelBlogs.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }

        public UserDTO User { get; set; }

        public PostDTO Post { get; set; }

    }
}
