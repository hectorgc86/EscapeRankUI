
/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Modelos
{
    public class Amigo : Usuario
    {
        public Estado Estado { get; set; }
    }

    public enum Estado
    {
        pendiente,
        aceptado,
        borrado
    }
}
