using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

namespace EscapeRankUI.Servicios
{
    public class MuroService : IMuroService
    {
        private readonly HttpClient client;

        public MuroService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        //Llamada a la API para traer todas las noticias que pertenecen a un usuario.

        public async Task<List<Noticia>> GetNoticiasAsync()
        {
            int usuarioId = App.UsuarioPrincipal.Id;
            List<Noticia> noticias = new List<Noticia>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.NoticiasUsuarioURL + usuarioId));
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);
                if (resp.IsSuccessStatusCode)
                {
                   string aux = await resp.Content.ReadAsStringAsync();

                    noticias = JsonConvert.DeserializeObject<List<Noticia>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return noticias;
        }
    }
}
