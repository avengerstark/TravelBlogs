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

                cfg.CreateMap<Comment, CommentDTO>().ReverseMap();

                cfg.CreateMap<CoordinatesInfo, CoordinatesInfoDTO>().ReverseMap();

                cfg.CreateMap<Follower, FollowerDTO>().ReverseMap();

                cfg.CreateMap<Post, PostDTO>().ForMember(post => post.Commets, opt => opt.Ignore())
                                              .ForMember(p => p.Votes, v => v.Ignore()).ReverseMap();

                cfg.CreateMap<TravelBlogs.DAL.Entities.Profile, ProfileDTO>().ReverseMap();

                cfg.CreateMap<ReplayToComment, ReplayToCommentDTO>().ReverseMap();

                cfg.CreateMap<ApplicationRole, RoleDTO>().ReverseMap();

                cfg.CreateMap<ApplicationUser, UserDTO>().ReverseMap();

                cfg.CreateMap<Vote, VoteDTO>().ReverseMap();



                cfg.CreateMap<Func<PostDTO, bool>, Func<Post, bool>>().ReverseMap();
                cfg.CreateMap<Func<CommentDTO, bool>, Func<Comment, bool>>().ReverseMap();
                cfg.CreateMap<Func<CountryDTO, bool>, Func<Country, bool>>().ReverseMap();
                cfg.CreateMap<Func<PlaceDTO, bool>, Func<Place, bool>>().ReverseMap();
                cfg.CreateMap<Func<RegionDTO, bool>, Func<Region, bool>>().ReverseMap();
            });
    
        } 
    }
}
