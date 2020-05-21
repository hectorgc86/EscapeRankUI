using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
       
        public Perfil Perfil { get; set; }
        public List<Equipo> Equipos { get; set; }
        public List<Noticia> Noticias { get; set; }
        public List<Amigo> Amigos { get; set; }
    }

}
