using Ecommerce.Data.Commons.Extensions;
using Ecommerce.Data.Enums;

namespace Ecommerce.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryText { get; private set; }  // É mapeada pelo BD
        
        //[JsonIgnore]
        public CategoryEnum Name                           // Não mapeada para BD, usada somente no OO
        {
            get { return CategoryExtensions.ToValue_(CategoryText); }
            set { CategoryText = CategoryExtensions.ToString_(value); }
        }
    }
}