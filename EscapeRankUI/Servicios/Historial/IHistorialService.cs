using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Servicios
{
    public interface IHistorialService
    {
        Task<List<Partida>> GetHistorialAsync(int usuarioId);
    }
}