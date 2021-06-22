using System.Globalization;

namespace StoneEntrevista.Application.Helpers
{
    public static class CurrencySerializer
    {
        public static string DecimalToString(decimal decimalValue)
        {
            return decimalValue.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}