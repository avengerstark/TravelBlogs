using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public double GeoLong { get; set; } // долгота - для карт google

        public double GeoLat { get; set; } // широта - для карт google

        public int RegionId { get; set; }
    }
}