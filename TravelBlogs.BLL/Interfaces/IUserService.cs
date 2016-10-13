using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;

namespace TravelBlogs.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ValidationException> Create(UserDTO userDto); // создание пользователей
        Task<ClaimsIdentity> Authenticate(string email, string password); // аутентификация пользователей
        Task<ValidationException> ChangePassword(string userId, string oldPassword, string newPassword); // смена пароля
        Task SetInitialData(UserDTO adminDto, List<string> roles); // установка начальных данных в БД - админа и списка ролей
    }
}
