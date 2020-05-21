using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public class Partida
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public string Imagen { get; set; }
        public byte[] Foto { get; set; }
        public Equipo Equipo { get; set; }
        public Sala Sala { get; set; }
        public int PosicionRanking { get; set; }

        public string ImagenPartida
        {
            get =>  (Imagen != null) ? Constantes.ImagenesPartidasURL + Imagen : Constantes.ImagenDefaultURL ;
        }

        public TimeSpan DuracionPartida
        {
                get => TimeSpan.FromMilliseconds(Minutos * 60 * 1000 + Segundos * 1000);
         }
    }
}