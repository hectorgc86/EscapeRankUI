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

        public Task<Login> GetLoginAsync(string usuario, string contrasenya)
        {
            return _servicio.GetLoginAsync(usuario,contrasenya);
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

        public async Task<SignUpResponse> SignUpAsync(Usuario user)
        {
            return await _servicio.SignUpAsync(user);

        }
    }

}
