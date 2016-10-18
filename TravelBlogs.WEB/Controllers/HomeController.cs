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

namespace TravelBlogs.WEB.Controllers
{
    public class HomeController : Controller
    {
        readonly ITravelBlogsService _travelService;
        public HomeController(ITravelBlogsService tbs)
        {
            _travelService = tbs;
        }


        public ActionResult Index()
        {
            return View();
        }

        // Временно

        public ActionResult Add()
        {
            CountryDTO country = new CountryDTO { Name = "Spasergin", Description = "Inquisition" };
            _travelService.Locations.CreateCountry(country);

            RegionDTO region = new RegionDTO { Name = "Rosrgme", Description = "OaerMG", CountryId = country.Id };
            _travelService.Locations.CreateRegion(region);

            PlaceDTO place = new PlaceDTO { Name = "Vatisergaercan", GeoLat = 85, GeoLong = 20, RegionId = region.Id };
            _travelService.Locations.CreatePlace(place);

            _travelService.SaveChanges();


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
                _travelService.Posts.Create(post);
            }
            return RedirectToAction("Index");
        }






        // For testing


        public ActionResult GetCountries()
        {
            List<CountryDTO> model = _travelService.Locations.GetAllCountries() as List<CountryDTO>;
            return View(model);
        }


        public ActionResult FindCountries(Expression<Func<CountryDTO, bool>> pred)
        {
            List<CountryDTO> countries = (List<CountryDTO>)_travelService.Locations.Find(pred);
            return View(countries);
        }
        
        public ActionResult SaveCountry(CountryDTO country)
        {
            _travelService.Locations.CreateCountry(country);
            _travelService.SaveChanges();
            return View(country);

        }





        protected override void Dispose(bool disposing)
        {
            _travelService.Dispose();
            base.Dispose(disposing);
        }

    }
}