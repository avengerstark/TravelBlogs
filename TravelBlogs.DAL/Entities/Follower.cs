using TravelBlogs.DAL.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogs.DAL.Entities
{
    public class Follower
    {
        public string StarUserId { get; set; }

        public int FollowerUserId { get; set; }

        [InverseProperty("StarUsers")]
        [ForeignKey("StarUserId")]
        public virtual ApplicationUser StarUser { get; set; }

        [InverseProperty("FollowerUsers")]
        [ForeignKey("FollowerUserId")]
        public virtual ApplicationUser FollowerUser { get; set; }
    }
}
