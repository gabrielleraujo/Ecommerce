using Ecommerce.Data.Commons.Extensions;
using Ecommerce.Data.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ecommerce.Data.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorText { get; private set; }        // É mapeada pelo BD

        //[JsonIgnore]
        public ColorEnum Name                                 // Não mapeada para BD, usada somente no OO
        {
            get { return ColorExtensions.ToValue_(ColorText); }
            set { ColorText = ColorExtensions.ToString_(value); }
        }

        //[JsonIgnore]
        public IList<Product> Produtos { get; set; }
    }
}