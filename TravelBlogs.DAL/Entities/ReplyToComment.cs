﻿using System;
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
    public class ReplyToComment
    {

        public int MainCommentId { get; set; }

        public int ReplayToCommentId { get; set; }

        [InverseProperty("MainComments")]
        [ForeignKey("MainCommentId")]
        public virtual Comment MainComment { get; set; }


        [InverseProperty("RepliesToComment")]
        [ForeignKey("ReplayToCommentId")]
        public virtual Comment ReplayToComment { get; set; }

    }
}
