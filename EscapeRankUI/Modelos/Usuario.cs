using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Usuario
    {
        private DateTime? _nacido;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
        public string Telefono { get; set; }
        public int? CodigoActivado { get; set; }
        public string Avatar { get; set; }
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

        public DateTime? Nacido
        {
            get => _nacido; set
            {
                if (value.HasValue)
                {
                    Edad = CalcularEdad((DateTime)value);
                }
                _nacido = value;
            }
        }

        private int CalcularEdad(DateTime nacido)
        {
            DateTime now = DateTime.Now;
            {
                int edad = now.Year - nacido.Year;
                if (now.Month < nacido.Month || (now.Month == nacido.Month && now.Day < nacido.Day))
                    edad--;

                return edad;
            }
        }
    }
}
