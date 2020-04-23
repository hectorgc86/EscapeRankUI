using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public class PartidaManager
    {
        private IPartidaService _servicio;

        public PartidaManager(IPartidaService servicio)
		{
			_servicio = servicio;
		}

		public Task<List<Partida>> GetPartidasAsync()
		{
			return _servicio.GetPartidasAsync();
		}

		public Task<Partida> GetPartidaAsync(int partidaId)
		{
			return _servicio.GetPartidaAsync(partidaId);	
		}

        public Task PostPartidaAsync(Partida partida)
		{
			return _servicio.PostPartidaAsync(partida);
		}

		public Task DeletePartidaAsync(int equipoId, Partida partida)
		{
			return _servicio.DeletePartidaAsync(equipoId, partida);
		}
    }
}
