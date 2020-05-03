using System;
using System.Text;
using Xamarin.Forms;
using System.Security.Cryptography;
using System.Collections.Generic;
using EscapeRankUI.Estilos;

namespace EscapeRankUI
{
    public static class Utils
    {
        public static object GetResourceValue(string recurso)
        {
            if (Application.Current.Resources.TryGetValue(recurso, out var retVal)) { }

            return retVal;
        }

        public static string CalcularMD5(string contrasenya)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(contrasenya);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
