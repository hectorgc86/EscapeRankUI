using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Newtonsoft.Json;

namespace EscapeRankUI.Servicios
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient client;

        public LoginService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
            };
        }

        //Llamada a la API para mandar usuario y contraseña y recibir autorización para loguearse.

        public async Task<Login> GetLoginAsync(string usuario, string contrasenya)
        {
            Login login = new Login();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.LoginURL);

            string req = JsonConvert.SerializeObject(new { usuario, contrasenya });
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        login = JsonConvert.DeserializeObject<Login>(aux);
                        break;
                    case HttpStatusCode.BadRequest:
                        throw new HttpBadRequestException();
                }

                return login;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Llamada a la API para mandar nombre, email y contraseña y registrar un usuario.

        public async Task<Login> PostRegistroAsync(Usuario usuario)
        {
            Login login = new Login();

            Uri uri = new Uri(Constantes.EscapeRankURL + Constantes.RegistroURL);

            string req = JsonConvert.SerializeObject(usuario);
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string aux = await resp.Content.ReadAsStringAsync();
                        login = JsonConvert.DeserializeObject<Login>(aux);
                        break;
                    case HttpStatusCode.Conflict:
                        throw new HttpConflictException();
                }

                return login;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}