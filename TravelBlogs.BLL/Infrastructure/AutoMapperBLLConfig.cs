using AutoMapper;
using TravelBlogs.BLL.DTO;
using TravelBlogs.DAL.Entities;
using TravelBlogs.BLL.Infrastructure;
using TravelBlogs.DAL.Infrastructure;

namespace TravelBlogs.BLL.Infrastructure
{

    public class AutoMapperBLLConfig : AutoMapper.Profile
    {
        public AutoMapperBLLConfig()
        {
            CreateMap<Country, CountryDTO>()
                    .ForMember(count => count.Regions, opt => opt.Ignore())
                    .ReverseMap();
            CreateMap<Region, RegionDTO>()
                    .ForMember(reg => reg.Places, opt => opt.Ignore())
                    .ReverseMap();
            CreateMap<Place, PlaceDTO>()
                    .ForMember(pl => pl.Posts, opt => opt.Ignore());
            CreateMap<PlaceDTO, Place>()
                    .ForMember(pl => pl.Posts, opt => opt.Ignore());
            CreateMap<Comment, CommentDTO>()
                .ForMember(c => c.User, opt => opt.MapFrom(u => u.ApplicationUser));
            CreateMap<CoordinatesInfo, CoordinatesInfoDTO>()
                    .ReverseMap();
            CreateMap<Follower, FollowerDTO>()
                    .ReverseMap();
            CreateMap<Post, PostDTO>()
                    .ForMember(post => post.Commets, opt => opt.Ignore())
                    .ForMember(p => p.Votes, v => v.Ignore())
                    .ForMember(p => p.User, opt => opt.MapFrom(u => u.ApplicationUser))
                    .ReverseMap();
            CreateMap<DAL.Entities.Profile, ProfileDTO>()
                    .ForMember(u => u.User, opt => opt.MapFrom(ap => ap.ApplicationUser))
                    .ReverseMap();
            CreateMap<ReplayToComment, ReplayToCommentDTO>()
                    .ReverseMap();
            CreateMap<ApplicationRole, RoleDTO>()
                    .ReverseMap();
            CreateMap<ApplicationUser, UserDTO>()
                    .ForMember(user => user.Role, opt => opt.Ignore())
                    .ForMember(u => u.Password, p => p.Ignore());
            CreateMap<UserDTO, ApplicationUser>()
                    .ForMember(u => u.Comments, opt => opt.Ignore())
                    .ForMember(u => u.FollowerUsers, opt => opt.Ignore())
                    .ForMember(u => u.Posts, opt => opt.Ignore())
                    .ForMember(u => u.StarUsers, opt => opt.Ignore())
                    .ForMember(u => u.Votes, opt => opt.Ignore());
            CreateMap<Vote, VoteDTO>()
                    .ReverseMap();
            CreateMap<PagingInfo, PagingInfoDTO>()
                .ReverseMap();
        }
    }
}
