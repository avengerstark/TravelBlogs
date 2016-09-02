using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class VoteViewModel
    {
        public int PostId { get; set; }
        public string UserId { get; set; }

        public bool IsLike { get; set; }
    }
}