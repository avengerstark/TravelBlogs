using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogs.DAL.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        [Key]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
