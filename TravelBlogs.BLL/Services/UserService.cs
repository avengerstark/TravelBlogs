using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.DAL.Entities;
using TravelBlogs.BLL.Infrastructure;
using Microsoft.AspNet.Identity;

namespace TravelBlogs.BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _db;

        public UserService(IUnitOfWork uow)
        {
            this._db = uow;
        }

        public async Task<ValidationException> Create(UserDTO userDto)
        {
            ApplicationUser user = await _db.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await _db.UserManager.CreateAsync(user, userDto.Password);
                // добовляем роль
                await _db.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                return new ValidationException("Регистрация успешно пройдена", "", true);
            }
            else
            {
                return new ValidationException("Пользователь с таким логином уже существует", "Email", false);
            }
            
        }

        public async Task<ClaimsIdentity> Authenticate(string email, string password)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _db.UserManager.FindAsync(email, password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
            {
                claim = await _db.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }


        public async Task<ValidationException> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            IdentityResult result = await _db.UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);
            if (result.Succeeded)
            {
                return new ValidationException("Ваш пароль изменен","", true);
            }
            return new ValidationException("Не удалось изменить ваш пароль","Password", false);
        }


        public async Task SetInitialData(DTO.UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                ApplicationRole role = await _db.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole {Name = roleName};
                    await _db.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }



    }
}
