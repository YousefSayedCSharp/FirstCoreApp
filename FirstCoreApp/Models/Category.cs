using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstCoreApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name="Category Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Display(Name="Category Description")]
        public string Description { get; set; }

        public List<News> News{ get; set; }
    }
}
