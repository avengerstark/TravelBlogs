using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }

        public string UserId { get; set; }
    }
}