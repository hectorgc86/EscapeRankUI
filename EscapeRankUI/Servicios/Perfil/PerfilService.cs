using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

namespace EscapeRankUI.Servicios
{
    public class PerfilService : IPerfilService
    {
        private readonly HttpClient client;

        public PerfilService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        //Llamada a la API para traer al usuario principal de la app.

        public async Task<Usuario> GetUsuarioAsync()
        {
            int usuarioId = App.UsuarioPrincipal.Id;
            Usuario usuario = new Usuario();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.UsuarioDetalleURL + usuarioId));

            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Usuario>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return usuario;
        }

        //Llamada a la API para traer los amigos del usuario principal de la app.

        public async Task<List<Usuario>> GetAmigosAsync()
        {
            int usuarioId = App.UsuarioPrincipal.Id;
            List<Usuario> amigos = new List<Usuario>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.UsuarioDetalleURL + usuarioId + Constants.AmigosURL));
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    amigos = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return amigos;
        }

        //Llamada a la API para traer a un amigo.

        public async Task<Usuario> GetAmigoAsync(int amigoId)
        {
            Usuario amigo = new Usuario();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.UsuarioDetalleURL));

            string postBody = @"id=" + amigoId;
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    amigo = JsonConvert.DeserializeObject<Usuario>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return amigo;
        }

        //Llamada a la API para traer los equipos del usuario principal de la app.

        public async Task<List<Equipo>> GetEquiposAsync()
        {
            int usuarioId = App.UsuarioPrincipal.Id;
            List<Equipo> equipos = new List<Equipo>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.UsuarioDetalleURL + usuarioId + Constants.EquiposURL));
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);

                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    equipos = JsonConvert.DeserializeObject<List<Equipo>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return equipos;
        }

        //Llamada a la API para traer un equipo.

        public async Task<Equipo> GetEquipoAsync(int equipoId)
        {
            Equipo equipo = new Equipo();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.EquiposDetalleURL + equipoId));

            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    equipo = JsonConvert.DeserializeObject<Equipo>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return equipo;
        }
    }
}
