using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

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

        public async Task<List<Sala>> GetSalasAsync (int offset)
		{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            List<Sala> salas = new List<Sala>();

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.SalasConjuntoURL + offset));
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);

                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    salas = JsonConvert.DeserializeObject<List<Sala>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return salas;
        }

        //Llamada a la API para traer todas las salas que cumplen con el estado "promocionada"

        public async Task<List<Sala>> GetSalasPromocionadasAsync(int offset)
        {
            List<Sala> salasPromocionadas = new List<Sala>();
            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.SalasPromocionadasURL + offset));
            try
            {
                HttpResponseMessage resp = await client.GetAsync(uri);

                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    salasPromocionadas = JsonConvert.DeserializeObject<List<Sala>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return salasPromocionadas;
        }

        //Llamada a la API para traer una sala.

        public async Task<Sala> GetSalaAsync(string salaId)
        {
            Sala sala = new Sala();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.SalasDetalleURL + salaId));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    sala = JsonConvert.DeserializeObject<Sala>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }

            return sala;
        }

        //Llamada a la API para traer todas las temáticas de juego.

        public async Task<List<Tematica>> GetTematicasAsync()
        {
            List<Tematica> tematicas = new List<Tematica>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.ThemesUrl));
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, null);
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    tematicas = JsonConvert.DeserializeObject<List<Tematica>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return tematicas;
        }

        //Llamada a la API para traer todas las categorias de juego.

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            List<Categoria> categorias = new List<Categoria>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.CategoriesUrl));
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, null);
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    categorias = JsonConvert.DeserializeObject<List<Categoria>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return categorias;
        }

        //Llamada a la API para traer tipo de público.

        public async Task<List<Publico>> GetPublicoAsync()
        {
            List<Publico> publico = new List<Publico>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.AudiencesUrl));

            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, null);
                if (resp.IsSuccessStatusCode)
                {
                   string aux = await resp.Content.ReadAsStringAsync();
                   publico = JsonConvert.DeserializeObject<List<Publico>>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return publico;
        }

        //Llamada a la API para traer todas las provincias.

        public async Task<List<Provincia>> GetProvinciasAsync()
        {
            List<Provincia> provincias = new List<Provincia>();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.CredencialesService.TokenAcceso);

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.ProvincesUrl));

            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, null);

                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    provincias = JsonConvert.DeserializeObject<List<Provincia>>(aux);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }
           
            return provincias;
        }
    }
}
