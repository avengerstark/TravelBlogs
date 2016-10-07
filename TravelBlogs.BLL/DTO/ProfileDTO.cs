using System;

namespace TravelBlogs.BLL.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }


        public string UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
