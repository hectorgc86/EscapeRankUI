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

		public Task<List<Sala>> GetSalasAsync(int offset, string busqueda)
		{
			return _servicio.GetSalasAsync(offset, busqueda);	
		}

        public Task<List<Sala>> GetSalasPromocionadasAsync(int offset)
        {
            return _servicio.GetSalasPromocionadasAsync(offset);
        }

        public Task<List<Sala>> GetSalasCategoriaAsync(string categoriaId, int offset, string busqueda)
        {
            return _servicio.GetSalasCategoriaAsync(categoriaId, offset, busqueda);
        }

        public Task<List<Sala>> GetSalasTematicaAsync(string tematicaId, int offset, string busqueda)
        {
            return _servicio.GetSalasTematicaAsync(tematicaId, offset, busqueda);
        }

        public Task<List<Sala>> GetSalasPublicoAsync(string publicoId, int offset, string busqueda)
        {
            return _servicio.GetSalasPublicoAsync(publicoId, offset, busqueda);
        }

        public Task<List<Sala>> GetSalasDificultadAsync(string dificultadId, int offset, string busqueda)
        {
            return _servicio.GetSalasDificultadAsync(dificultadId, offset, busqueda);
        }

        public Task<List<Sala>> GetSalasProvinciaAsync(string provinciaId, int offset)
        {
            return _servicio.GetSalasProvinciaAsync(provinciaId, offset);
        }

        public Task<List<Partida>> GetPartidasSalaAsync(string salaId, int offset)
        {
            return _servicio.GetPartidasSalaAsync(salaId, offset);
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
