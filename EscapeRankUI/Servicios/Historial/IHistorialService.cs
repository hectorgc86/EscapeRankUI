using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IHistorialService
    {
        Task<List<Partida>> GetHistorialAsync(int usuarioId);
    }
}