using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CoordinatesInfoDTO CoordinatesInfo { get; set; }

        public PlaceDTO()
        {
            CoordinatesInfo = new CoordinatesInfoDTO();
        }

        public int RegionId { get; set; }
    }
}
