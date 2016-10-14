using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.DTO;

namespace TravelBlogs.WEB.Controllers
{
    public class PostController : Controller
    {
        readonly ITravelBlogsService _travelService;

        public PostController(ITravelBlogsService ts)
        {
            _travelService = ts;
        }



        // GET: Post
        public ActionResult GetPost(int id)
        {
            PostDTO post = _travelService.Posts.Get(id);
            return View(post);
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel model)
        {
            PostDTO post = new PostDTO
            {
                Title = model.Title,
                Body = model.Body,
                CreateDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IsApproved = true,
                PlaceId = 1

            };
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            _travelService.Posts.Create(post);
            _travelService.Save();
            return RedirectToAction("Index","Home");
        }
        
    }
}