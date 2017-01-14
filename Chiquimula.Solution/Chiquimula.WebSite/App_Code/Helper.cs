using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Chiquimula.WebSite
{
    public class Helper
    {
        public static decimal ConvertToDecimal(string texto, string separadorDecimalTexto = ".")
        {
            var separadorActual = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var texto2 = texto.Replace(separadorDecimalTexto, separadorActual);
            decimal val = decimal.Zero;
            decimal.TryParse(texto2, out val);
            return val;
        }
    }
}