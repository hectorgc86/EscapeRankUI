using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IPartidaService
    {
        Task<List<Partida>> GetPartidasAsync();
        Task<Partida> GetPartidaAsync(int id);
        Task PostPartidaAsync(Partida partida);
        Task DeletePartidaAsync(int equipoId, Partida partida);
    }
}