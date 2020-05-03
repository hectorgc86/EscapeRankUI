using System;
using System.Collections.Generic;
using System.Linq;
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
                        string aux = await resp.Content.ReadAsStringAsync();
                        guardada = JsonConvert.DeserializeObject<bool>(aux);

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

        public async Task<List<Sala>> GetSalasCategoriaAsync(string categoriaId, int offset, string busqueda)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Sala> salasCategoria = new List<Sala>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.SalasCategoriaURL + categoriaId
                + Constantes.OffsetQuery + offset
                + Constantes.BusquedaQuery + busqueda);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        salasCategoria = JsonConvert.DeserializeObject<List<Sala>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return salasCategoria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
