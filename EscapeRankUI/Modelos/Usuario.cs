using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Usuario
    {
      
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
        public DateTime? Nacido { get; set; }
        public string Telefono { get; set; }
        public int Activado { get; set; }
        public int? CodigoActivado { get; set; }
        public string Avatar { get; set; }
        [JsonIgnore]
        public int? Edad { get; set; }
        public Perfil Perfil { get; set; }
        public List<Equipo> Equipos { get; set; }
        public List<Noticia> Noticias { get; set; }
        public List<Usuario> Amigos { get; set; }
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
