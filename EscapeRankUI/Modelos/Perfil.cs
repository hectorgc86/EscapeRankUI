using System;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public int? NumeroPartidas { get; set; }
        public int? PartidasGanadas { get; set; }
        public int? PartidasPerdidas { get; set; }
        public DateTime? MejorTiempo { get; set; }
    }
}
