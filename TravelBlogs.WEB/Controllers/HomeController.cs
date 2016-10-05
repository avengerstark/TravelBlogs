using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.DTO;
using AutoMapper;


using TravelBlogs.DAL.Entities;

namespace TravelBlogs.WEB.Controllers
{
    public class HomeController : Controller
    {
        readonly ITravelBlogsService travelService;
        public HomeController(ITravelBlogsService tbs)
        {
            travelService = tbs;
        }

        // Временно

        public ActionResult Add()
        {

            CountryDTO country = new CountryDTO { Name = "France", Description = "lol" };
            travelService.Locations.CreateCountry(country);

            RegionDTO region = new RegionDTO { Name = "avgawdfa", Description = "sdevgfawaw", CountryId = country.Id };
            travelService.Locations.CreateRegion(region);

            PlaceDTO place = new PlaceDTO { Name = " arewgawergaqwrg", GeoLat = 5, GeoLong = 85, RegionId = region.Id };
            travelService.Locations.CreatePlace(place);

            travelService.Save();

            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }






        // For testing


        public ActionResult GetCountries()
        {
            List<CountryDTO> model = travelService.Locations.GetAllCountries() as List<CountryDTO>;
            return View(model);
        }


        public ActionResult FindCountries(Expression<Func<CountryDTO, bool>> pred)
        {
            List<CountryDTO> countries = (List<CountryDTO>)travelService.Locations.Find(pred);
            return View(countries);
        }
        
        public ActionResult SaveCountry(CountryDTO country)
        {
            travelService.Locations.CreateCountry(country);
            travelService.Save();
            return View(country);

        }





        protected override void Dispose(bool disposing)
        {
            travelService.Dispose();
            base.Dispose(disposing);
        }

    }
}