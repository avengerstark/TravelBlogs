using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string TextComment { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }

        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


        public virtual ICollection<ReplyToComment> RepliesToComment { get; set; }

        public Comment()
        {
            RepliesToComment = new List<ReplyToComment>();
        }
    }
}
