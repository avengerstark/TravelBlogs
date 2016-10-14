using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TravelBlogs.WEB.Models
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Основная часть")]
        public string Body { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int Rating { get; set; }

        public int CountComments { get; set; }


        public string UserId { get; set; }

        public int PlaceId { get; set; }
    }
}