﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.BLL.DTO
{
    public class VoteDTO
    {
        public int PostId { get; set; }
        public string UserId { get; set; }

        public bool IsLike { get; set; }
    }
}
