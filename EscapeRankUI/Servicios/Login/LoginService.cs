using System;
using System.Diagnostics;
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

        //Llamada a la API para mandar email y contraseña y recibir autorización para loguearse.

        public async Task<Login> GetLoginAsync(string email, string contrasenya)
        {
            Login login = new Login();

            Uri uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.LoginURL));

            string req = JsonConvert.SerializeObject(new { email , contrasenya });
            try
            {
                HttpResponseMessage resp = await client.PostAsync(uri, new StringContent(req, Encoding.UTF8, "application/json"));
                if (resp.IsSuccessStatusCode)
                {
                    string aux = await resp.Content.ReadAsStringAsync();
                    login = JsonConvert.DeserializeObject<Login>(aux);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@" ERROR {0}", ex.Message);
            }

            return login;
        }

        public async Task<Login> GetTokenClientCredentialsAsync()
        {
            Login token = new Login();
        var uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.LoginURL));
        string postBody = @"client_id=" + Constants.ClientId + "&client_secret=" + Constants.ClientSecret + "&grant_type=client_credentials";

            try
            {
                var response = await client.PostAsync(uri, new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"));
        string responseStream = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var deserialized = JsonConvert.DeserializeObject<Login>(responseStream);
        token = deserialized;
                }
                else
                {
                    token = JsonConvert.DeserializeObject<Login>(responseStream);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@" ERROR {0}", ex.Message);
            }

            return token;
        }


        public async Task<Login> ValidateToken()
        {
            var loginToken = new Login();
            var token = App.CredencialesService.TokenAcceso;

            if (await ValidateTokenRequest(token))
            {
                loginToken.TokenAcceso = token;
                return loginToken;
            }
            if (await ValidateTokenRequest(loginToken.TokenAcceso))
            {
                return loginToken;
            }
            return null;

        }

        private async Task<bool> ValidateTokenRequest(string token)
        {
            var uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.TokenValidateUrl));
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes("Bearer " + validateToken));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync(uri, null);
            string responseStream = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }



        public async Task<Login> GetTokenImplicitAsync(string state = "", string redirectionUri = "")
        {
            Login token = new Login();
            string getBody = @"?client_id=" + Constants.ClientId + "&response_type=token&state=" + state + "&redirect_uri=" + redirectionUri;
            var uriString = string.Format(Constants.EscapeRankURL, Constants.TokenAuthorizeUrl);
            var uri = new Uri(string.Format(uriString, getBody));

            try
            {
                var response = await client.GetAsync(uri);


                string responseStream = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<Login>(responseStream);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@" ERROR {0}", ex.Message);
            }

            return token;
        }

        public async Task<Login> GetTokenAuthorizationCodeAsync(string code, string redirectionUri = "")
        {
            Login token = new Login();

            var uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.TokenAuthorizeUrl));
            string postBody = @"client_id=" + Constants.ClientId + "&client_secret=" + Constants.ClientSecret + "&grant_type=authorization_code&code=" + code + "&redirect_uri=" + redirectionUri;

            try
            {
                var response = await client.PostAsync(uri, new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"));


                string responseStream = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<Login>(responseStream);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@" ERROR {0}", ex.Message);
            }

            return token;
        }

        public async Task<SignUpResponse> SignUpAsync(Usuario user)
        {
            SignUpResponse signUpResponse = new SignUpResponse();
            var uri = new Uri(string.Format(Constants.EscapeRankURL, Constants.SignUpUrl));
            string postBody = @"Username=" + user.Nombre + "&Password=" + user.Contrasenya + "&Mail=" + user.Email;

            try
            {
                var response = await client.PostAsync(uri, new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"));
                string responseStream = await response.Content.ReadAsStringAsync();
                signUpResponse = JsonConvert.DeserializeObject<SignUpResponse>(responseStream);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@" ERROR {0}", ex.Message);
            }
            return signUpResponse;
        }

        public Task<Login> GetTokenRefreshTokenAsync(string refresh_token)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetCodeAuthorizationCodeAsync(string state = "", string redirectionUri = "")
        {
            throw new NotImplementedException();
        }
    }
}