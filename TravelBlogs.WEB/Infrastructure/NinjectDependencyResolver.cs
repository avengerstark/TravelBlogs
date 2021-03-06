﻿using System;
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
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<ITravelBlogsService>().To<TravelBlogsService>();
        }
    }
}