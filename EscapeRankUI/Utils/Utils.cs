using System;
using System.Text;
using Xamarin.Forms;
using System.Security.Cryptography;

namespace EscapeRankUI
{
    public static class Utils
    {
        public static string RegexEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public static string RegexNacido = @"^([0-2][0-9]|3[0-1])(\/)(0[1-9]|1[0-2])\2(\d{4})$";

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
