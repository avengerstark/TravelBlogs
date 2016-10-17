using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Текст комментария")]
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }
    }
}