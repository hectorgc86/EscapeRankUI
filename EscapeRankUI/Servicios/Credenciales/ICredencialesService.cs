using System.Threading.Tasks;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Servicios
{
    public interface ICredencialesService
    {
        Task<string> GetUsuarioId();

        Task<string> GetToken();

        Task<string> GetTema();

        Task GuardarTema(string tema);

        Task GuardarCredenciales(string email, string contrasenya, Login login);

        void BorrarCredenciales();

        Task<bool> ComprobarCredenciales();
    }
}
