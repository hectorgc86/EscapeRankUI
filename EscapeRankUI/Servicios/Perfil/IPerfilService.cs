using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IPerfilService
    {
        Task<Usuario> GetUsuarioAsync();

        Task<List<Usuario>> GetAmigosAsync();

        Task<Usuario> GetAmigoAsync(int amigoId);

        Task<List<Equipo>> GetEquiposAsync();

        Task<Equipo> GetEquipoAsync(int equipoId);
    }
}