
using System.Collections.Generic;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Categoria
    {
        private string tipo;
        public string Id { get; set; }
        public int NumeroSalas { get; set; }

        public string Tipo { get => tipo; set => tipo = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }

        public FontImageSource Icono
        {
            get
            {
                return (FontImageSource)Utils.GetResourceValue("icono_cat_" + Tipo.ToLower());
            }
            set { Icono = value; }
        }
    }
}
