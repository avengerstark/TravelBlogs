using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelBlogs.DAL.Entities
{
    public class Country
    {
        public int PostId { get; set; }
        [Required]
        public string CountryName { get; set; }

        public string Description { get; set; }


        // Навигационные свойства
        public virtual ICollection<Region> Regions { get; set; }

        public Country()
        {
            Regions = new List<Region>();
        }
    }
}
