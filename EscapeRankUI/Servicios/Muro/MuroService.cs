using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            int usuarioId = App.UsuarioPrincipal.Id;
            List<Noticia> noticias = new List<Noticia>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.NoticiasUsuarioURL + usuarioId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        noticias = JsonConvert.DeserializeObject<List<Noticia>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return noticias;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
