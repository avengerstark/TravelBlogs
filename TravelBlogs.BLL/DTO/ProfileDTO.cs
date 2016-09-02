using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }


        public string UserId { get; set; }
    }
}
