using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ProductRegistrationViewModel
    {
        public ProductRegistrationViewModel() { }

        public ProductRegistrationViewModel(IList<CategoryDetailsViewModel> categories, IList<ColorDetailsViewModel> colors, IList<SizeDetailsViewModel> sizes)
        {
            Categories = categories;
            Colors = colors;
            Sizes = sizes;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "The Price field must have a value of at least 0.1.")]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public int SizeId { get; set; }

        public IList<CategoryDetailsViewModel> Categories { get; set; }
        public IList<ColorDetailsViewModel> Colors { get; set; }
        public IList<SizeDetailsViewModel> Sizes { get; set; }
    }
}