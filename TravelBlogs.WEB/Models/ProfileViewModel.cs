using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }


        public string UserId { get; set; }
    }
}