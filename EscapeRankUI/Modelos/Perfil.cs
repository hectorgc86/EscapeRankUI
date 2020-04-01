using System;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Perfil
    {
        public int Id { get; set; }
        public int? NumeroPartidas { get; set; }
        public int? PartidasGanadas { get; set; }
        public int? PartidasPerdidas { get; set; }
        public DateTime? MejorTiempo { get; set; }
        public string Avatar { get; set; }
        public string Nick { get; set; }
        public ImageSource AvatarUri
        {
            get
            {
                if (!string.IsNullOrEmpty(Avatar))
                {
                    string url = Avatar;
                    return ImageSource.FromUri(new Uri(url, UriKind.Absolute));
                }
                return null;
            }
            set { AvatarUri = value; }
        }
    }
}
