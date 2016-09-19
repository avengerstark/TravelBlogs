using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlogs.DAL.Entities
{
    public class ReplayToComment
    {

        public int MainCommentId { get; set; }

        public int ReplayToCommentId { get; set; }

        [InverseProperty("MainComments")]
        [ForeignKey("MainCommentId")]
        public virtual Comment MainComments { get; set; }


        [InverseProperty("RepliesToComment")]
        [ForeignKey("ReplayToCommentId")]
        public virtual Comment RepliesToComment { get; set; }

    }
}
