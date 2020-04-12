
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Dificultad
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public int NumeroSalas { get; set; }

        public FontImageSource Icono
        {
            get
            {
                return (FontImageSource)Utils.GetResourceValue("icono_dif_" + Tipo.ToLower());
            }
            set { Icono = value; }
        }
    }
}
