using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class RegionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наменование")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public int CountryId { get; set; }
    }
}