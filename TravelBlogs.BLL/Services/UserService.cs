using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.Interfaces;

namespace TravelBlogs.BLL.Services
{
    public class UserService : IUserService
    {

        public Task<Infrastructure.ValidationException> Create(DTO.UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public Task<System.Security.Claims.ClaimsIdentity> Authenticate(DTO.UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public Task SetInitialData(DTO.UserDTO adminDto, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
