using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using TravelBlogs.BLL.Infrastructure;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.Services;
using System.Web.Mvc;

namespace TravelBlogs.WEB.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ITravelBlogsService>().To<TravelBlogsService>();
        }
    }
}