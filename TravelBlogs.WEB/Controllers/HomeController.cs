using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.DTO;
using AutoMapper;


using TravelBlogs.DAL.Entities;

namespace TravelBlogs.WEB.Controllers
{
    public class HomeController : Controller
    {
        ITravelBlogsService travelService;
        public HomeController(ITravelBlogsService tbs)
        {
            travelService = tbs;
        }

        public ActionResult Add()
        {
            //PostDTO post = new PostDTO { Title = ";sd", Body = "adlvfl6464", CreateDate = DateTime.Now,
            //                             ModificationDate = DateTime.Now,
            //                             IsApproved = false,
            //                             PlaceId = 1,
            //                             UserId = "f6e7ea56-df77-463c-b5bb-16e103e8db4d",
            //                             Rating=1,
            //                             CountComments=514,
            //};
            //travelService.Posts.Create(post);


            CountryDTO country = new CountryDTO { Name = "Holland", Description = "lol" };
            travelService.Locations.CreateCountry(country);

            RegionDTO region = new RegionDTO { Name = "avgawdfa", Description = "sdevgfawaw", CountryId = country.Id };
            travelService.Locations.CreateRegion(region);

            PlaceDTO place = new PlaceDTO { Name = " arewgawergaqwrg", GeoLat = 5, GeoLong = 85, RegionId = region.Id };
            travelService.Locations.CreatePlace(place);

            travelService.Save();

            return RedirectToAction("Lol");
        }


        public ActionResult CreatePost()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel postView)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<PostViewModel, PostDTO>().BeforeMap((pv, p) => pv.CreateDate = DateTime.Now)
                                                .BeforeMap((pv, p) => pv.ModificationDate = DateTime.Now)
                                                .BeforeMap((pv, p) => pv.IsApproved = false));
                PostDTO post = Mapper.Map<PostViewModel, PostDTO>(postView);
                travelService.Posts.Create(post);
            }
            return RedirectToAction("Lol");
        }



        protected override void Dispose(bool disposing)
        {
            travelService.Dispose();
            base.Dispose(disposing);
        }

    }
}