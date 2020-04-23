
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Tematica
    {
        private string tipo;

        public string Id { get; set; }

        public string Tipo { get => tipo; set => tipo = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());}

        public int NumeroSalas { get; set; }

        public FontImageSource Icono
        {
            get
            {
                return (FontImageSource)Utils.GetResourceValue("icono_tem_" + Tipo.ToLower());
            }
            set { Icono = value; }
        }
    }
}
