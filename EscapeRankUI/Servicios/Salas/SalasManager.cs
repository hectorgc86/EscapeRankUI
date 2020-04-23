using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public class SalasManager
    {
		ISalasService _servicio;

        public SalasManager(ISalasService servicio)
		{
            _servicio = servicio;
		}

		public Task<List<Sala>> GetSalasAsync(int offset)
		{
			return _servicio.GetSalasAsync(offset);	
		}

        public Task<List<Sala>> GetSalasPromocionadasAsync(int offset)
        {
            return _servicio.GetSalasPromocionadasAsync(offset);
        }

        public Task<List<Partida>> GetPartidasSalaAsync(string salaId)
        {
            return _servicio.GetPartidasSalaAsync(salaId);
        }

        public Task<Sala> GetSalaAsync(string salaId)
        {
            return _servicio.GetSalaAsync(salaId);
        }

        public Task<List<Tematica>> GetTematicasAsync()
        {
            return _servicio.GetTematicasAsync();
        }

        public Task<List<Categoria>> GetCategoriasAsync()
        {
            return _servicio.GetCategoriasAsync();
        }
        public Task<List<Publico>> GetPublicoAsync()
        {
            return _servicio.GetPublicoAsync();
        }

        public Task<List<Dificultad>> GetDificultadesAsync()
        {
            return _servicio.GetDificultadesAsync();
        }

        public Task<List<Provincia>> GetProvinciasAsync()
        {
            return _servicio.GetProvinciasAsync();
        }
    }
}
