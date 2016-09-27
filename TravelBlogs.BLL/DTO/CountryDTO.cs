﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
