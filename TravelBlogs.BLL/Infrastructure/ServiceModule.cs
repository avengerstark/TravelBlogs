using Ninject.Modules;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.DAL.Repositories;

namespace TravelBlogs.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
