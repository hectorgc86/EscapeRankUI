using System;

namespace EscapeRankUI.Modelos
{
    public class Partida
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Horas { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public Equipo Equipo { get; set; }
        public Sala Sala { get; set; }
    }
}