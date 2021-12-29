using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ProductRegistrationViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}