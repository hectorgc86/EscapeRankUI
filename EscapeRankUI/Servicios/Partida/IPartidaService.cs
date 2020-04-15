using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IPartidaService
    {
        Task<Partida> GetPartidaAsync(int id);
        Task<List<Partida>> GetPartidasAsync();
        Task SavePartidaAsync(Partida item, bool isNewItem);
        Task DeletePartidaAsync(int idTeam, Partida partida);
    }
}