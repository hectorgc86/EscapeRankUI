using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public interface ISalasService
	{
		Task<List<Sala>> GetSalasAsync (int offset);

        Task<List<Sala>> GetSalasPromocionadasAsync(int offset);

        Task<List<Partida>> GetPartidasSalaAsync(string salaId);

        Task<Sala> GetSalaAsync(string salaId);

        Task<List<Tematica>> GetTematicasAsync();

        Task<List<Categoria>> GetCategoriasAsync();

        Task<List<Publico>> GetPublicoAsync();

        Task<List<Dificultad>> GetDificultadesAsync();

        Task<List<Provincia>> GetProvinciasAsync();
    }
}
