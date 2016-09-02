using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using TravelBlogs.DAL.Repositories;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.WEB.Infrastructure
{
    public class NinjectDependencyResolver
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
            
        }
    }
}