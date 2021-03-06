﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class Place
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public double GeoLong { get; set; } // долгота - для карт google

        public double GeoLat { get; set; } // широта - для карт google

        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }


        // Навигационные свойства
        public virtual ICollection<Post> Posts { get; set; }
    }
}
