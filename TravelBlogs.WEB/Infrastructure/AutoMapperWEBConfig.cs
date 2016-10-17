using System.Web.UI.WebControls;
using AutoMapper;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.DTO;

namespace TravelBlogs.WEB.Infrastructure
{
    public class AutoMapperWEBConfig
    {
        public static void Configure()
        {
            RegisterMapping();
        }

        private static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                // PostDTO <---> PostViewModel
                cfg.CreateMap<PostDTO, PostViewModel>();
                cfg.CreateMap<PostViewModel, PostDTO>()
                    .ForMember(p => p.Commets, opt => opt.Ignore())
                    .ForMember(p => p.Votes, opt => opt.Ignore())
                    .ForMember(p => p.User, opt => opt.Ignore())
                    .ForMember(p => p.Place, opt => opt.Ignore());

                // CommentDTO <---> CommentViewModel
                cfg.CreateMap<CommentDTO, CommentViewModel>();
                cfg.CreateMap<CommentViewModel, CommentDTO>()
                    .ForMember(c => c.Post, opt => opt.Ignore())
                    .ForMember(c => c.Post, opt => opt.Ignore());


                // CountryDTO <---> CountryViewModel
                cfg.CreateMap<CountryDTO, CountryViewModel>();
                cfg.CreateMap<CountryViewModel, CountryDTO>()
                    .ForMember(c => c.Regions, opt => opt.Ignore());

                // FollowerDTO <---> FollowerViewModel
                cfg.CreateMap<FollowerDTO, FollowerViewModel>().ReverseMap();


                // PlaceDTO <---> PlaceViewModel
                cfg.CreateMap<PlaceDTO, PlaceViewModel>();
                cfg.CreateMap<PlaceViewModel, PlaceDTO>()
                    .ForMember(p => p.Posts, opt => opt.Ignore())
                    .ForMember(p => p.Region, opt => opt.Ignore());

                // ProfileDTO <---> ProfileViewModel
                cfg.CreateMap<ProfileDTO, ProfileViewModel>();
                cfg.CreateMap<ProfileViewModel, ProfileDTO>()
                    .ForMember(p => p.User, opt => opt.Ignore());


                // RegionDTO <---> RegionViewModel
                cfg.CreateMap<RegionDTO, RegionViewModel>();
                cfg.CreateMap<RegionViewModel, RegionDTO>()
                    .ForMember(r => r.Places, opt => opt.Ignore())
                    .ForMember(r => r.Country, opt => opt.Ignore());


                // ReplayToCommentDTO <---> ReplayToCommentViewModel
                cfg.CreateMap<ReplayToCommentDTO, ReplayToCommentViewModel>().ReverseMap();


                // RoleDTO <---> RoleViewModel
                cfg.CreateMap<RoleDTO, RoleViewModel>().ReverseMap();


                // VoteDTO <---> VoteViewModel
                cfg.CreateMap<VoteDTO, VoteViewModel>().ReverseMap();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}