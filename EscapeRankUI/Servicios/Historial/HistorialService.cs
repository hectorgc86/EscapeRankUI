using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                List<Partida> partidasUsuario = new List<Partida>();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

                Uri uri = new Uri(Constants.EscapeRankURL + Constants.PartidasUsuarioURL + usuarioId);
                try
                {
                    HttpResponseMessage resp = await client.GetAsync(uri);
                    if (resp.IsSuccessStatusCode)
                    {
                        string aux = await resp.Content.ReadAsStringAsync();
                        partidasUsuario = JsonConvert.DeserializeObject<List<Partida>>(aux);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                }

                return partidasUsuario;
           
        }
    }
}
