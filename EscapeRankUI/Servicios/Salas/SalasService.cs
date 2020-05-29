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
	public class SalasService : ISalasService
    {
        private readonly HttpClient client;

        public SalasService()
		{
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        //Llamada a la API para traer todas las salas según su paginado.

        public async Task<List<Sala>> GetSalasAsync (int offset, string busqueda)
		{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Sala> salas = new List<Sala>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.SalasURL
                + Constantes.OffsetQuery + offset
                + Constantes.BusquedaQuery + busqueda);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        salas = JsonConvert.DeserializeObject<List<Sala>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return salas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las salas que cumplen con el estado "promocionada"

        public async Task<List<Sala>> GetSalasPromocionadasAsync(int offset)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Sala> salasPromocionadas = new List<Sala>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.SalasPromocionadasURL
                + Constantes.OffsetQuery + offset);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                            string aux = await resp.Content.ReadAsStringAsync();
                            salasPromocionadas = JsonConvert.DeserializeObject<List<Sala>>(aux);
                            break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return salasPromocionadas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las salas de una categoria

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

        //Llamada a la API para traer todas las salas de una tematica

        public async Task<List<Sala>> GetSalasTematicaAsync(string tematicaId, int offset, string busqueda)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Sala> salasTematica = new List<Sala>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.SalasTematicaURL + tematicaId
                + Constantes.OffsetQuery + offset
                + Constantes.BusquedaQuery + busqueda);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        salasTematica = JsonConvert.DeserializeObject<List<Sala>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return salasTematica;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las salas de un publico

        public async Task<List<Sala>> GetSalasPublicoAsync(string publicoId, int offset, string busqueda)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Sala> salasPublico = new List<Sala>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.SalasPublicoURL + publicoId
                + Constantes.OffsetQuery + offset
                + Constantes.BusquedaQuery + busqueda);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        salasPublico = JsonConvert.DeserializeObject<List<Sala>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return salasPublico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las salas de una dificultad

        public async Task<List<Sala>> GetSalasDificultadAsync(string dificultadId, int offset, string busqueda)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Sala> salasDificultad = new List<Sala>();
            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.SalasDificultadURL + dificultadId
                + Constantes.OffsetQuery + offset
                + Constantes.BusquedaQuery + busqueda);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        salasDificultad = JsonConvert.DeserializeObject<List<Sala>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return salasDificultad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las partidas de una sala

        public async Task<List<Partida>> GetPartidasSalaAsync(string salaId, int offset)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Partida> partidasSala = new List<Partida>();

            Uri uri = new Uri(Constantes.EscapeRankURL
                + Constantes.PartidasSalaURL + salaId
                + Constantes.OffsetQuery + offset);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        partidasSala = JsonConvert.DeserializeObject<List<Partida>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return partidasSala;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer una sala.

        public async Task<Sala> GetSalaAsync(string salaId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Sala sala = new Sala();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.SalasDetalleURL + salaId);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        sala = JsonConvert.DeserializeObject<Sala>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return sala;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las temáticas de juego.

        public async Task<List<Tematica>> GetTematicasAsync()
        {
            List<Tematica> tematicas = new List<Tematica>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.TematicasURL);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        tematicas = JsonConvert.DeserializeObject<List<Tematica>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return tematicas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las categorias de juego.

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            List<Categoria> categorias = new List<Categoria>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.CategoriasURL);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        categorias = JsonConvert.DeserializeObject<List<Categoria>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return categorias;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Llamada a la API para traer tipo de público.

        public async Task<List<Publico>> GetPublicoAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Publico> publico = new List<Publico>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.PublicoURL);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        publico = JsonConvert.DeserializeObject<List<Publico>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return publico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer tipos de dificultad.

        public async Task<List<Dificultad>> GetDificultadesAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Dificultad> dificultades = new List<Dificultad>();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.DificultadesURL);
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        dificultades = JsonConvert.DeserializeObject<List<Dificultad>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return dificultades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para traer todas las provincias.

        public async Task<List<Provincia>> GetProvinciasAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await App.CredencialesService.GetToken());

            List<Provincia> provincias = new List<Provincia>();

            Uri uri = new Uri(string.Format(Constantes.EscapeRankURL, Constantes.ProvinciasURL));
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        provincias = JsonConvert.DeserializeObject<List<Provincia>>(aux);
                        break;
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException();
                }

                return provincias;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
