using System;
using Xamarin.Forms;

namespace EscapeRankUI
{
    public static class Utils
    {
        public static object GetResourceValue(string keyName)
        {
            if (Application.Current.Resources.TryGetValue(keyName, out var retVal)) { }
            return retVal;
        }
    }
}
