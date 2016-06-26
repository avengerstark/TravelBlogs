using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class ReplyToComment
    {
        public int ReplyToCommentId { get; set; }

        public string TextComment { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }


        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }


    }
}
