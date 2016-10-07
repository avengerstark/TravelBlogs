using System.Collections.Generic;

namespace TravelBlogs.BLL.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Навигационные свойства
        public List<RegionDTO> Regions { get; set; }
    }
}
