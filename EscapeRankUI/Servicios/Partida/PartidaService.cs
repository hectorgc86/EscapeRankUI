using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

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

        // Llamada a la API para registrar una partida

        public async Task<bool> PostPartidaAsync(Partida partida)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            bool guardada = false;

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.PartidasURL);

            string req = JsonConvert.SerializeObject(partida);
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        guardada = true;
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return guardada;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
