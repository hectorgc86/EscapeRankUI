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

        public async Task<Partida> GetPartidaAsync(int id)
        {
            return await Task.Run(() =>
            {
                return new Partida();
            });
        }

        public async Task PostPartidaAsync(Partida partida)
        {
            await Task.Run(() =>
            {
                return null;
            });
        }

        public async Task DeletePartidaAsync(int equipoId, Partida Partida)
        {
            await Task.Run(() =>
            {

            });
        }

    }
}
