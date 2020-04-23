using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public class PerfilManager
    {
		IPerfilService _servicio;

        public PerfilManager(IPerfilService servicio)
		{
            _servicio = servicio;
		}

		public Task<Usuario> GetUsuarioAsync()
		{
			return _servicio.GetUsuarioAsync();	
		}
      
        public Task<List<Usuario>> GetAmigosAsync()
        {
            return _servicio.GetAmigosAsync();
        }

        public Task<Usuario> GetAmigoAsync(int amigoId)
        {
            return _servicio.GetAmigoAsync(amigoId);
        }

        public Task<List<Equipo>> GetEquiposAsync()
        {
            return _servicio.GetEquiposAsync();
        }

        public Task<List<Usuario>> GetMiembrosEquipoAsync(int equipoId)
        {
            return _servicio.GetMiembrosEquipoAsync(equipoId);
        }

        public Task<List<Partida>> GetPartidasEquipoAsync(int equipoId)
        {
            return _servicio.GetPartidasEquipoAsync(equipoId);
        }
    }
}
