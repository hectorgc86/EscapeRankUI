using System;
using System.Collections.Generic;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Modelos
{
    public class Equipo
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activado { get; set; }
        public string Avatar { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Partida> Partidas { get; set; }

        public string AvatarEquipo
        {
            get => Avatar + Id;
        }

    }
}
