using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsBanned { get; set; }

        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        // Навигационные свойства

        public virtual ICollection<ReplayToComment> MainComments { get; set; }

        public virtual ICollection<ReplayToComment> RepliesToComment { get; set; }

    }
}
