using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class Region
    {
        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public string Description { get; set; }



        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }



        // Навигационные свойства
        public virtual ICollection<Place> Places {get; set;}

        public Region()
        {
            Places = new List<Place>();
        }

    }
}
