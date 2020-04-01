using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Avatar { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Partida> Partidas { get; set; }
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
