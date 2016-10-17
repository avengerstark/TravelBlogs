using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlogs.WEB.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display (Name = "Наименование")]
        public string Name { get; set; }

    }
}