using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IPerfilService
    {
        Task<Usuario> GetUsuarioAsync();

        Task<Amigo> GetAmigoAsync(int amigoId);

        Task<List<Amigo>> GetAmigosAsync();

        Task<List<Equipo>> GetEquiposAsync();

        Task<List<Usuario>> GetMiembrosEquipoAsync(int equipoId);

        Task<List<Partida>> GetPartidasEquipoAsync(int equipoId);

        Task<bool> PostAmigoAsync(string emailAmigo);

        Task<bool> PostEquipoAsync(Equipo equipo);

        Task<bool> PutAmigoAsync(Amigo amigo);

        Task<bool> DeleteAmigoAsync(int amigoId);

        Task<bool> DeleteEquipoAsync(int equipoId);

    }
}