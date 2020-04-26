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
    }
}
