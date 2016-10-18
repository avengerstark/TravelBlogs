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
            PostViewModel postView = new PostViewModel
            {
                Title = post.Title,
                Body = post.Body
            };
            return View(postView);
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel model)
        {
            model.CreateDate = DateTime.Now;
            model.ModificationDate = DateTime.Now;
            model.PlaceId = 1;
            model.IsApproved = true;
            PostDTO post = Mapper.Map<PostDTO>(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _travelService.Posts.Create(post);
            _travelService.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        
    }
}