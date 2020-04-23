using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IPerfilService
    {
        Task<Usuario> GetUsuarioAsync();

        Task<Usuario> GetAmigoAsync(int amigoId);

        Task<List<Usuario>> GetAmigosAsync();

        Task<List<Equipo>> GetEquiposAsync();

        Task<List<Usuario>> GetMiembrosEquipoAsync(int equipoId);

        Task<List<Partida>> GetPartidasEquipoAsync(int equipoId);
    }
}