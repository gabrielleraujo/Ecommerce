using Ecommerce.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Data.Commons.Extensions
{
    public static class CategoryExtensions
    {
        private static Dictionary<string, CategoryEnum> mapa = new Dictionary<string, CategoryEnum>()
        {
            { "tshirt", CategoryEnum.TShirt },
            { "shirt", CategoryEnum.Shirt },
            { "blouse", CategoryEnum.Blouse },
            { "jacket", CategoryEnum.Jacket },
            { "coat", CategoryEnum.Coat },
            { "pants", CategoryEnum.Pants },
            { "shorts", CategoryEnum.Shorts },
            { "skirt", CategoryEnum.Skirt },
            { "dress", CategoryEnum.Dress }
        };

        public static string ToString_(CategoryEnum categoria)
        {
            return mapa.First(m => m.Value == categoria).Key;
        }

        public static CategoryEnum ToValue_(string texto)
        {
            return mapa.First(m => m.Key == texto).Value;
        }
    }
}