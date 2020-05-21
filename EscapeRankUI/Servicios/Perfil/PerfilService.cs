using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string usuarioId = await App.CredencialesService.GetUsuarioId();

            Usuario usuario = new Usuario();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.UsuarioDetalleURL + usuarioId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        usuario = JsonConvert.DeserializeObject<Usuario>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        //Llamada a la API para traer a un amigo.

        public async Task<Amigo> GetAmigoAsync(int amigoId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Amigo amigo = new Amigo();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.UsuarioDetalleURL + amigoId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        amigo = JsonConvert.DeserializeObject<Amigo>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return amigo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer los amigos del usuario principal de la app.

        public async Task<List<Amigo>> GetAmigosAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            int usuarioId = App.UsuarioPrincipal.Id;
            List<Amigo> amigos = new List<Amigo>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.UsuarioDetalleURL + usuarioId
                + Constantes.AmigosURL);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        amigos = JsonConvert.DeserializeObject<List<Amigo>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return amigos;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Llamada a la API para traer los equipos del usuario principal de la app.

        public async Task<List<Equipo>> GetEquiposAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            int usuarioId = App.UsuarioPrincipal.Id;
            List<Equipo> equipos = new List<Equipo>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.EquiposUsuarioURL + usuarioId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        equipos = JsonConvert.DeserializeObject<List<Equipo>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return equipos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer los miembros de un equipo.

        public async Task<List<Usuario>> GetMiembrosEquipoAsync(int equipoId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Usuario> miembros = new List<Usuario>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.UsuariosEquipoURL + equipoId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        miembros = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return miembros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer las partidas de un equipo.

        public async Task<List<Partida>> GetPartidasEquipoAsync(int equipoId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Partida> partidas = new List<Partida>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.PartidasEquipoURL + equipoId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        partidas = JsonConvert.DeserializeObject<List<Partida>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return partidas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> PostAmigoAsync(string emailAmigo)
        {
            bool creado = false;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            int usuarioId = App.UsuarioPrincipal.Id;
            Uri uri = new Uri(Constantes.EscapeRankURL
                 + Constantes.UsuarioDetalleURL + usuarioId + Constantes.AmigosURL);

            string req = JsonConvert.SerializeObject(emailAmigo);
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        creado = true;
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                    case HttpStatusCode.NotFound:
                        throw new HttpNotFoundException();
                }

                return creado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> PostEquipoAsync(Equipo equipo)
        {
            bool creado = false;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.EquiposURL);

            string req = JsonConvert.SerializeObject(equipo);
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                            creado = true;
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                    case HttpStatusCode.Conflict:
                        throw new HttpConflictException();
                }

                return creado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> PutAmigoAsync(Amigo amigo)
        {
            bool creado = false;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            int usuarioId = App.UsuarioPrincipal.Id;
            Uri uri = new Uri(Constantes.EscapeRankURL
                 + Constantes.UsuarioDetalleURL + usuarioId
                 + Constantes.AmigosDetalleURL + amigo.Id);

            string req = JsonConvert.SerializeObject(amigo);
            try
            {
                HttpResponseMessage resp = await client.PutAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        creado = true;
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                    case HttpStatusCode.Conflict:
                        throw new HttpConflictException();
                }

                return creado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAmigoAsync(int amigoId)
        {
            bool borrado = false;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            int usuarioId = App.UsuarioPrincipal.Id;
            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.UsuarioDetalleURL + usuarioId
                + Constantes.AmigosDetalleURL + amigoId);
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync(uri);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        borrado = true;
                        break;
                    case HttpStatusCode.NotFound:
                        throw new HttpNotFoundException();
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return borrado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEquipoAsync(int equipoId)
        {
            bool borrado = false;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.EquiposDetalleURL + equipoId);
            try
            {
                HttpResponseMessage resp = await client.DeleteAsync(uri);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        borrado = true;
                        break;
                    case HttpStatusCode.NotFound:
                        throw new HttpNotFoundException();
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return borrado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
