using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public class PartidaService : IPartidaService
    {
        private readonly HttpClient client;

        public PartidaService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<List<Partida>> GetPartidasAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Partida>();
            });
        }

        public async Task DeletePartidaAsync(int idTeam, Partida Partida)
        {
            await Task.Run(() =>
            {
                //FakeData.Users.FirstOrDefault((arg) => arg.IdUsuarios.Equals(UserId)).
                //TeamList.FirstOrDefault((arg) => arg.Id == idTeam).
               // Partidas.Remove(Partida);
            });
        }

        public async Task<Partida> GetPartidaAsync(int id)
        {
            return await Task.Run(() =>
            {
                return new Partida();// FakeData.Partidas.FirstOrDefault((arg) => arg.Id == id);
            });
        }

        public async Task SavePartidaAsync(Partida item, bool isNewItem)
        {
             await Task.Run(() =>
            {
                return null;// FakeData.Partidas.Add(item);
            });
        }
    }
}
