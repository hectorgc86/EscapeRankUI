using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

namespace EscapeRankUI.Servicios
{
    public class HistorialService : IHistorialService
    {
        private readonly HttpClient client;

        public HistorialService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<List<Partida>> GetHistorialAsync(int usuarioId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Partida> partidasUsuario = new List<Partida>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.PartidasUsuarioURL + usuarioId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        partidasUsuario = JsonConvert.DeserializeObject<List<Partida>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return partidasUsuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
