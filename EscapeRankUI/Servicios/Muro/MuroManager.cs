using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public class MuroManager
    {
		private readonly IMuroService _servicio;

        public MuroManager(IMuroService servicio)
		{
			_servicio = servicio;
		}

		public Task<List<Noticia>> GetNoticiasAsync()
		{
			return _servicio.GetNoticiasAsync();	
		}
    }
}
