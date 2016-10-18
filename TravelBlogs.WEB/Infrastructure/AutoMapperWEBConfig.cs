using AutoMapper;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.DTO;

namespace TravelBlogs.WEB.Infrastructure
{
    public class AutoMapperWEBConfig : Profile
    {
        public AutoMapperWEBConfig()
        {
            // PostDTO <---> PostViewModel
            CreateMap<PostDTO, PostViewModel>();
            CreateMap<PostViewModel, PostDTO>()
                    .ForMember(p => p.Commets, opt => opt.Ignore())
                    .ForMember(p => p.Votes, opt => opt.Ignore())
                    .ForMember(p => p.User, opt => opt.Ignore())
                    .ForMember(p => p.Place, opt => opt.Ignore());

            // CommentDTO <---> CommentViewModel
            CreateMap<CommentDTO, CommentViewModel>();
            CreateMap<CommentViewModel, CommentDTO>()
                    .ForMember(c => c.Post, opt => opt.Ignore())
                    .ForMember(c => c.User, opt => opt.Ignore());

            // CountryDTO <---> CountryViewModel
            CreateMap<CountryDTO, CountryViewModel>();
            CreateMap<CountryViewModel, CountryDTO>()
                    .ForMember(c => c.Regions, opt => opt.Ignore());

            // FollowerDTO <---> FollowerViewModel
            CreateMap<FollowerDTO, FollowerViewModel>()
                .ReverseMap();

            // PlaceDTO <---> PlaceViewModel
            CreateMap<PlaceDTO, PlaceViewModel>();
            CreateMap<PlaceViewModel, PlaceDTO>()
                    .ForMember(p => p.Posts, opt => opt.Ignore())
                    .ForMember(p => p.Region, opt => opt.Ignore());


            // ProfileDTO <---> ProfileViewModel
            CreateMap<ProfileDTO, ProfileViewModel>();
            CreateMap<ProfileViewModel, ProfileDTO>()
                    .ForMember(p => p.User, opt => opt.Ignore());

            // RegionDTO <---> RegionViewModel
            CreateMap<RegionDTO, RegionViewModel>();
            CreateMap<RegionViewModel, RegionDTO>()
                    .ForMember(r => r.Places, opt => opt.Ignore())
                    .ForMember(r => r.Country, opt => opt.Ignore());


            // ReplayToCommentDTO <---> ReplayToCommentViewModel
            CreateMap<ReplayToCommentDTO, ReplayToCommentViewModel>()
                .ReverseMap();


            // RoleDTO <---> RoleViewModel
            CreateMap<RoleDTO, RoleViewModel>()
                .ReverseMap();


            // VoteDTO <---> VoteViewModel
            CreateMap<VoteDTO, VoteViewModel>()
                .ReverseMap();
        }     
    }
}