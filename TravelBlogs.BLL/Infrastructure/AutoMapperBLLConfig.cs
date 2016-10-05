using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.DTO;
using TravelBlogs.DAL.Entities;

namespace TravelBlogs.BLL.Infrastructure
{
    public class AutoMapperBLLConfig
    {

        public static void Configure()
        {
            RegisterMapping();
        }

        private static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Country, CountryDTO>().ForMember(count => count.Regions, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<Region, RegionDTO>().ForMember(reg => reg.Places, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<Place, PlaceDTO>().ForMember(pl => pl.Posts, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<Comment, CommentDTO>().ForMember(com => com.User, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<CoordinatesInfo, CoordinatesInfoDTO>().ReverseMap();

                cfg.CreateMap<Follower, FollowerDTO>().ReverseMap();

                cfg.CreateMap<Post, PostDTO>().ForMember(post => post.Commets, opt => opt.Ignore())
                                              .ForMember(p => p.Votes, v => v.Ignore())
                                              .ForMember(u => u.User, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<TravelBlogs.DAL.Entities.Profile, ProfileDTO>().ForMember(prof => prof.User, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<ReplayToComment, ReplayToCommentDTO>().ReverseMap();

                cfg.CreateMap<ApplicationRole, RoleDTO>().ReverseMap();

                cfg.CreateMap<ApplicationUser, UserDTO>().ForMember(user => user.Role, opt => opt.Ignore())
                                                         .ForMember(u => u.Password, p => p.Ignore()).ReverseMap();

                cfg.CreateMap<Vote, VoteDTO>().ReverseMap();

            });


            Mapper.AssertConfigurationIsValid();
    
        } 
    }
}
