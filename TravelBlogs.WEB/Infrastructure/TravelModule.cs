using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.DAL.Repositories;

namespace TravelBlogs.WEB.Infrastructure
{
    public class TravelModule : NinjectModule
    {
        private string connectionString;
        public TravelModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}