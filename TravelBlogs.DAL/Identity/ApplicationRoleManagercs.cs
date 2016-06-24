﻿using TravelBlogs.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelBlogs.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole> 
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
            : base(store)
        { }
    }
}
