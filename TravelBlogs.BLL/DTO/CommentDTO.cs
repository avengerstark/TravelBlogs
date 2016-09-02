using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
       
        public string Text { get; set; }
        
        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }

        public string UserId { get; set; }
    }
}
