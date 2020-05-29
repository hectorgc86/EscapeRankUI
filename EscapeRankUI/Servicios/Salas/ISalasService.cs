using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Servicios
{
	public interface ISalasService
	{
		Task<List<Sala>> GetSalasAsync(int offset, string busqueda);

        Task<List<Sala>> GetSalasPromocionadasAsync(int offset);

        Task<List<Sala>> GetSalasCategoriaAsync(string categoriaId, int offset, string busqueda);
        
        Task<List<Sala>> GetSalasTematicaAsync(string tematicaId, int offset, string busqueda);

        Task<List<Sala>> GetSalasPublicoAsync(string publicoId, int offset, string busqueda);

        Task<List<Sala>> GetSalasDificultadAsync(string dificultadId, int offset, string busqueda);

        Task<List<Partida>> GetPartidasSalaAsync(string salaId, int offset);

        Task<Sala> GetSalaAsync(string salaId);

        Task<List<Tematica>> GetTematicasAsync();

        Task<List<Categoria>> GetCategoriasAsync();

        Task<List<Publico>> GetPublicoAsync();

        Task<List<Dificultad>> GetDificultadesAsync();

        Task<List<Provincia>> GetProvinciasAsync();
    }
}
