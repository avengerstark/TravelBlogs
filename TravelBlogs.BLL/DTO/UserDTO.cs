using Microsoft.AspNet.Identity.EntityFramework;


namespace TravelBlogs.BLL.DTO
{
    public class UserDTO : IdentityUser
    {
        public string Password { get; set; }

        public string Role { get; set; }

        public ProfileDTO Profile { get; set; }
    }

}
