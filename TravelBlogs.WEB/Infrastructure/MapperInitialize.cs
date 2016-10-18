using AutoMapper;
using TravelBlogs.BLL.Infrastructure;

namespace TravelBlogs.WEB.Infrastructure
{
    public class MapperInitialize
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperBLLConfig>();
                cfg.AddProfile<AutoMapperWEBConfig>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}