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

        public CoordinatesInfoViewModel CoordinatesInfo { get; set; }

        public PlaceViewModel()
        {
            CoordinatesInfo = new CoordinatesInfoViewModel();
        }


        public int RegionId { get; set; }
    }
}