using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int Rating { get; set; }

        public int CountComments { get; set; }


        public string UserId { get; set; }

        //public virtual User User { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
