using AutoMapper;
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

                cfg.CreateMap<Country, CountryDTO>()
                    .ForMember(count => count.Regions, opt => opt.Ignore())
                    .ReverseMap();

                cfg.CreateMap<Region, RegionDTO>()
                    .ForMember(reg => reg.Places, opt => opt.Ignore())
                    .ReverseMap();

                cfg.CreateMap<Place, PlaceDTO>()
                    .ForMember(pl => pl.Posts, opt => opt.Ignore());

                cfg.CreateMap<PlaceDTO, Place>()
                    .ForMember(pl => pl.Posts, opt => opt.Ignore());

                cfg.CreateMap<Comment, CommentDTO>()
                    .ForMember(c => c.User, opt => opt.MapFrom(u => u.ApplicationUser))
                    .ReverseMap();

                cfg.CreateMap<CoordinatesInfo, CoordinatesInfoDTO>()
                    .ReverseMap();

                cfg.CreateMap<Follower, FollowerDTO>()
                    .ReverseMap();

                cfg.CreateMap<Post, PostDTO>()
                    .ForMember(post => post.Commets, opt => opt.Ignore())
                    .ForMember(p => p.Votes, v => v.Ignore())
                    .ForMember(p => p.User, opt => opt.MapFrom(u => u.ApplicationUser))
                    .ReverseMap();

                cfg.CreateMap<DAL.Entities.Profile, ProfileDTO>()
                    .ForMember(u => u.User, opt => opt.MapFrom(ap => ap.ApplicationUser))
                    .ReverseMap();

                cfg.CreateMap<ReplayToComment, ReplayToCommentDTO>()
                    .ReverseMap();

                cfg.CreateMap<ApplicationRole, RoleDTO>()
                    .ReverseMap();

                cfg.CreateMap<ApplicationUser, UserDTO>()
                    .ForMember(user => user.Role, opt => opt.Ignore())
                    .ForMember(u => u.Password, p => p.Ignore());

                cfg.CreateMap<UserDTO, ApplicationUser>()
                    .ForMember(u => u.Comments, opt => opt.Ignore())
                    .ForMember(u => u.FollowerUsers, opt => opt.Ignore())
                    .ForMember(u => u.Posts, opt => opt.Ignore())
                    .ForMember(u => u.StarUsers, opt => opt.Ignore())
                    .ForMember(u => u.Votes, opt => opt.Ignore());

                cfg.CreateMap<Vote, VoteDTO>()
                    .ReverseMap();

            });


            Mapper.AssertConfigurationIsValid();
    
        } 
    }
}
