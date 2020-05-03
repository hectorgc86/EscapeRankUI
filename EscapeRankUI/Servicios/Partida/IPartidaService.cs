using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IPartidaService
    {
        Task<bool> PostPartidaAsync(Partida partida);
    }
}