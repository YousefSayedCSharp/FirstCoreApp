using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCoreApp.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 25)]
        public string Topic { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("category ")]
        public int categoryId { get; set; }
        public Category category { get; set; }

        [Display(Name ="Select Image")]
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
