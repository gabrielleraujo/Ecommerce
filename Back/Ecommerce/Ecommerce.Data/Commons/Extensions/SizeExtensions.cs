using Ecommerce.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Data.Commons.Extensions
{
    public static class SizeExtensions
    {
        private static Dictionary<string, SizeEnum> mapa = new Dictionary<string, SizeEnum>()
        {
            { "PP", SizeEnum.PP },
            { "P", SizeEnum.P },
            { "M", SizeEnum.M },
            { "G", SizeEnum.G },
            { "GG", SizeEnum.GG }
        };

        public static string ToString_(SizeEnum tamanho)
        {
            return mapa.First(m => m.Value == tamanho).Key;
        }

        public static SizeEnum ToValue_(string texto)
        {
            return mapa.First(m => m.Key == texto).Value;
        }
    }
}