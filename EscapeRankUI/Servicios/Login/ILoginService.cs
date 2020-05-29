using System.Threading.Tasks;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Servicios
{
    public interface ILoginService
    {
        Task<Login> GetLoginAsync(string usuario, string contrasenya);

        Task<Login> PostRegistroAsync(Usuario usuario);
    }
}