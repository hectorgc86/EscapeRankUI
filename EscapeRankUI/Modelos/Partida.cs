using System;

namespace EscapeRankUI.Modelos
{
    public class Partida
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public Equipo Equipo { get; set; }
        public Sala Sala { get; set; }
        public int PosicionRanking { get; set; }

        public TimeSpan DuracionPartida {
            get
            {
                return TimeSpan.FromMilliseconds(Minutos * 60 * 1000 + Segundos * 1000);
            }
            set { DuracionPartida = value; }
        }
    }
}