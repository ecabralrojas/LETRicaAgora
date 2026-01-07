namespace LET.Agora.WebUI.Utlilidades
{
    public class Utilidad
    {

        public static bool ValidaRNC(string rnc)
        {
            string peso = "79865432";
            int suma = 0;
            int digito, resto = 0;


            if (rnc.Length != 9)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    suma += Convert.ToInt32(ToInteger(rnc.Substring(i, 1))) * Convert.ToInt32(ToInteger(peso.Substring(i, 1)));
                }

                resto = Convert.ToInt32(Modulo(suma, 11));

                if (resto == 0)
                {
                    digito = 2;
                }
                else if (resto == 1)
                {
                    digito = 1;
                }
                else
                {
                    digito = 11 - resto;
                }

                if (digito != Convert.ToInt32(rnc.Substring(rnc.Length - 1)))
                {
                    return false;

                }
            }
            return true;
        }

        private static string ToInteger(string vData)
        {
            return vData.Replace(",", "");
        }
        private static double Modulo(double decimalNumber, double decimalDivider)
        {
            return decimalNumber - Math.Truncate(decimalNumber / decimalDivider) * decimalDivider;
        }

        public static bool ValidarCedula(string cedula)
        {
            string peso = "1212121212";
            int resultado = 0;
            string multi = "";
            string a, b = "";
            int division, digito = 0;
            double el_numero, suma = 0;

            for (int i = 0; i < 10; i++)
            {
                resultado = (Convert.ToInt32(ToInteger(cedula.Substring(i, 1))) * Convert.ToInt32(ToInteger(peso.Substring(i, 1))));

                if (resultado > 9)
                {
                    multi = resultado.ToString();
                    a = ToInteger(multi.Substring(0, 1));
                    b = ToInteger(multi.Substring(1, 1));
                    resultado = Convert.ToInt32(a) + Convert.ToInt32(b);
                }

                suma += Convert.ToInt32(ToInteger(resultado.ToString()));
            }

            division = Convert.ToInt32(Math.Round(suma / 10)) * 10;

            if (suma > division)
            {
                el_numero = 10 - Convert.ToInt32((suma - division));
            }
            else
            {
                el_numero = 10 - Convert.ToInt32(10 - (division - suma));
            }

            if (el_numero < 10)
            {
                digito = Convert.ToInt32(el_numero);
            }
            else
            {
                digito = 10 - Convert.ToInt32((el_numero - Math.Round(el_numero / 10) * 10));
            }

            if (digito.ToString().Trim() != cedula.Substring(cedula.Length - 1))
            {
                return false;
            }

            return true;

        }
    }
}
