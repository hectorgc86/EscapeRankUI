
/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Modelos
{
    public class Login
    {
        public string UsuarioId { get; set; }
        public string TokenAcceso { get; set; }
        public string TipoToken { get; set; }
        public string ExpiraEn { get; set; }
    }
}
