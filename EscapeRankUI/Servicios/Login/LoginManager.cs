using System;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public class LoginManager
    {
        ILoginService _servicio;

        public LoginManager(ILoginService servicio)
        {
            _servicio = servicio;
        }

        public Task<Login> GetLoginAsync(string email, string contrasenya)
        {
            return _servicio.GetLoginAsync(email, contrasenya);
        }

        public async Task<Login> PostRegistroAsync(string nombre ,string email, string contrasenya)
        {
            return await _servicio.PostRegistroAsync(nombre, email, contrasenya);
        }

        public Task<Login> GetTokenClientCredentialsAsync()
        {
            return _servicio.GetTokenClientCredentialsAsync();
        }

        public Task<Login> GetTokenRefreshTokenAsync(string refreshToken)
        {
            return _servicio.GetTokenRefreshTokenAsync(refreshToken);
        }

        public Task<Login> GetTokenImplicitAsync(string state = "", string redirectionUri = "")
        {
            return _servicio.GetTokenImplicitAsync(state, redirectionUri);
        }

        public Task<Login> GetCodeAuthorizationCodeAsync(string state = "", string redirectionUri = "")
        {

            return _servicio.GetCodeAuthorizationCodeAsync(state, redirectionUri);
        }

        public Task<Login> GetTokenAuthorizationCodeAsync(string code, string redirectionUri = "")
        {
            return _servicio.GetTokenAuthorizationCodeAsync(code, redirectionUri);
        }
        public async Task<Login> ValidateToken()
        {
            return await _servicio.ValidateToken();
        }
    }

}
