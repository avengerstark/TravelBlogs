using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime DOB { get; set; }


        public string UserId { get; set; }
    }
}