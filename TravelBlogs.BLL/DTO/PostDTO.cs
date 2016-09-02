using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModificationDate { get; set; }


        public string UserId { get; set; }

        public int PlaceId { get; set; }

    }
}
