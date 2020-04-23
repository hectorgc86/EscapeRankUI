using System;
using Xamarin.Forms;

namespace EscapeRankUI
{
    public static class Utils
    {
        public static object GetResourceValue(string icono)
        {
            if (Application.Current.Resources.TryGetValue(icono, out var retVal)) { }

            return retVal;
        }

        public static int CalcularEdad(DateTime nacido)
        {
            DateTime now = DateTime.Now;
            {
                int edad = now.Year - nacido.Year;
                if (now.Month < now.Month || (now.Month == nacido.Month && now.Day < nacido.Day))
                    edad--;

                return edad;
            }
        }
    }
}
