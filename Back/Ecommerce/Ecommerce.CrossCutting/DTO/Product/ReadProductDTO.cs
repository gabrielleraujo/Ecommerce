using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.CrossCutting.DTO.Size;

namespace Ecommerce.CrossCutting.DTO.Product
{
    public class ReadProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public string Sizes { get => $"/sizes"; }
        public string Colors { get => $"/colors"; }

        public ReadCategoryDTO Category { get; set; }
        public ReadColorDTO Color { get; set; }
        public ReadSizeDTO Size { get; set; }
    }
}