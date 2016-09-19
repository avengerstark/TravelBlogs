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
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Post, PostDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, Post>());

            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, Comment>());

            Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<CountryDTO, Country>());

            Mapper.Initialize(cfg => cfg.CreateMap<Place, PlaceDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>());

            Mapper.Initialize(cfg => cfg.CreateMap<Region, RegionDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<RegionDTO, Region>());

            Mapper.Initialize(cfg => cfg.CreateMap<Vote, VoteDTO>());
            Mapper.Initialize(cfg => cfg.CreateMap<Vote, VoteDTO>());
            
        }
    }
}
