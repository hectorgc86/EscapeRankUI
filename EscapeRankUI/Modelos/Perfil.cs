using System;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Modelos
{
    public class Perfil
    {
        private DateTime? _nacido;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Avatar { get; set; }
        public int? Edad { get; set; }
        public int? NumeroPartidas { get; set; }
        public int? PartidasGanadas { get; set; }
        public int? PartidasPerdidas { get; set; }

        public string AvatarPerfil
        {
            get => Avatar + Id;
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
