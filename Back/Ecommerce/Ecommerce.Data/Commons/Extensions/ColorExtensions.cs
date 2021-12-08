using Ecommerce.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Data.Commons.Extensions
{
    public static class ColorExtensions
    {
        private static Dictionary<string, ColorEnum> mapa = new Dictionary<string, ColorEnum>()
        {
            { "white", ColorEnum.White },
            { "gray", ColorEnum.Gray },
            { "black", ColorEnum.Black },
            { "red", ColorEnum.Red },
            { "blue", ColorEnum.Blue },
            { "purple", ColorEnum.Purple },
            { "green", ColorEnum.Green }
        };

        public static Dictionary<string, ColorEnum> Mapa { get => mapa; set => mapa = value; }

        public static string ToString_(ColorEnum cor)
        {
            return Mapa.First(m => m.Value == cor).Key;
        }

        public static ColorEnum ToValue_(string texto)
        {
            return Mapa.First(m => m.Key == texto).Value;
        }
    }
}