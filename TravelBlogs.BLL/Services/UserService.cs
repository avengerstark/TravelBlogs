using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        private IUnitOfWork db;

        public UserService(IUnitOfWork uow)
        {
            this.db = uow;
        }

        public async Task<ValidationException> Create(DTO.UserDTO userDto)
        {
            ApplicationUser user = await db.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await db.UserManager.CreateAsync(user, userDto.Password);
                // добовляем роль
                await db.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                await db.SaveAsync();
                return new ValidationException("Регистрация успешно пройдена", "", true);
            }
            else
            {
                return new ValidationException("Пользователь с таким логином уже существует", "Email", false);
            }
            
        }

        public async Task<ClaimsIdentity> Authenticate(DTO.UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await db.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
            {
                claim = await db.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public async Task SetInitialData(DTO.UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                ApplicationRole role = await db.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole {Name = roleName};
                    await db.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
    }
}
