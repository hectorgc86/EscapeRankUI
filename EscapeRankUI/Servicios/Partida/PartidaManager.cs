using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
	public class PartidaManager
    {
        IPartidaService restService;

        public PartidaManager(IPartidaService service)
		{
			restService = service;
		}

		public Task<Partida> GetPartidaAsync(int id)
		{
			return restService.GetPartidaAsync(id);	
		}

        public Task<List<Partida>> GetPartidasAsync()
        {
            return restService.GetPartidasAsync();
        }
      
        public Task SavePartidaAsync(Partida item, bool isNewItem = false)
		{
			return restService.SavePartidaAsync(item, isNewItem);
		}

		public Task DeletePartidaAsync(int idTeam, Partida partida)
		{
			return restService.DeletePartidaAsync(idTeam, partida);
		}
    }
}
