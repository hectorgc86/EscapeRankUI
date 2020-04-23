using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public class HistorialManager
    {
        IHistorialService _servicio;

        public HistorialManager(IHistorialService servicio)
		{
			_servicio = servicio;
		}

		public Task<List<Partida>> GetHistorialAsync(int usuarioId)
		{
			return _servicio.GetHistorialAsync(usuarioId);	
		}
    }
}
