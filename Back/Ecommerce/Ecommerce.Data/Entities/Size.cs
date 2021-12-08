using Ecommerce.Data.Commons.Extensions;
using Ecommerce.Data.Enums;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string SizeText { get; private set; }    // É mapeada pelo BD
        
        //[JsonIgnore]
        public SizeEnum Name                             // Não mapeada para BD, usada somente no OO
        {
            get { return SizeExtensions.ToValue_(SizeText); }
            set { SizeText = SizeExtensions.ToString_(value); }
        }

        //[JsonIgnore]
        public IList<Product> Products { get; set; }
    }
}