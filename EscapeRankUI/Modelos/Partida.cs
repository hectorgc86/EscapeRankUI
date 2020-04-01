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
        public virtual Equipo Equipo { get; set; }
        public virtual Sala Sala { get; set; }
    }

    public class PartidaReq : Partida
    {
        public int Compania { get; set; }
        public int Codigo { get; set; }
        public int DuracionEscape { get; set;}
    }
}