using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.DTO
{
    public class RegionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CountryId { get; set; }

        public CountryDTO Country { get; set; }

        public List<PlaceDTO> Places { get; set; }
    }
}
