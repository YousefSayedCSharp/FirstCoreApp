using System;
using System.ComponentModel.DataAnnotations;

namespace FirstCoreApp.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name="Your name")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Message { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string Subject { get; set; }
    }
}
