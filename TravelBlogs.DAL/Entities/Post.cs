using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelBlogs.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int Rating { get; set; }

        public int CountComments { get; set; }


        // Связи с первичными ключами

        public string UserId { get; set; }
        [ForeignKey("UserId ")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int PlaceId { get; set; }
        [ForeignKey("Id")]
        public virtual Place Place { get; set; }


        // Навигационные свойства

        public virtual ICollection<Vote> Votes { get; set; }

        public Post()
        {
            Votes = new List<Vote>();
        }

    }
}
