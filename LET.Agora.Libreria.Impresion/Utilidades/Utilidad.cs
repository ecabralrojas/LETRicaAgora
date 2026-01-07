using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LET.Agora.Libreria.Impresion.Utilidades
{
    public class Utilidad
    {
        public static string RightZeroFill(string text)
        {
            return string.Format("{0:000000}", Convert.ToInt32(text));
        }
        public static string FormatLineas(string unidades, string descripcion, string montos, int LengthUnidad, int LenghtDescripcion, int LenghtMontos)
        {
            return string.Format("{0} {1} {2}",
                 EnsureLength(unidades, LengthUnidad, true),
                 EnsureLength(descripcion, LenghtDescripcion, false),
                 EnsureLength(montos, LenghtMontos, false));

        }
        private static string EnsureLength(string input, int requiredLength, bool padRight)
        {
            if (input.Length > requiredLength) return input.Substring(0, requiredLength);
            if (input.Length == requiredLength) return input;
            if (padRight)
            {
                return input.PadRight(requiredLength);
            }
            else
            {
                return input.PadLeft(requiredLength);
            }
        }
    }
}
