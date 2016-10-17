using System;
using System.Collections.Generic;

namespace TravelBlogs.BLL.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string DisplayBody { get; set; }

        public string Body { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int? Rating { get; set; }

        public int? CountComments { get; set; }


        public string UserId { get; set; }

        public int PlaceId { get; set; }

        public UserDTO User { get; set; }

        public PlaceDTO Place { get; set; }

        public List<VoteDTO> Votes { get; set; }

        public List<CommentDTO> Commets { get; set; }
    }
}
