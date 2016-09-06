using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.DTO;
using AutoMapper;

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
            CountryDTO country = new CountryDTO { Name = "France", Description = "croissants" };
            travelService.Locations.Create(country);
            return RedirectToAction("lol");
        }

    }
}