using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class Comment
    {
        public string ID { get; set; }

        public string TextComment { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }
    }
}
