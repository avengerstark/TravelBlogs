using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelBlogs.DAL.Entities
{
    public class Vote
    {
        [Required]
        public bool IsLike { get; set; }


        public int PostId { get; set; }
        [ForeignKey("Id")]
        public virtual Post Post { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
