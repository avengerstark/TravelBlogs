using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Временно
        public string Coordinates { get; set; }


        public int RegionId { get; set; }
    }
}