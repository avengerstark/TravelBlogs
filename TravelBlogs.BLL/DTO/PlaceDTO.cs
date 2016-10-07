using System.Collections.Generic;

namespace TravelBlogs.BLL.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double GeoLong { get; set; } // долгота - для карт google

        public double GeoLat { get; set; } // широта - для карт google

        public int RegionId { get; set; }

        public RegionDTO Region { get; set; }

        public List<PostDTO> Posts { get; set; }
    }
}
