using System;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public class LoginManager
    {
        ILoginService authService;

        public LoginManager(ILoginService service)
        {
            authService = service;
        }

        public Task<Login> GetLogin(string usuario, string contrasenya)
        {
            return authService.GetLogin(usuario,contrasenya);
        }

        public Task<Login> GetTokenClientCredentialsAsync()
        {
            return authService.GetTokenClientCredentialsAsync();
        }
    
        public Task<Login> GetTokenRefreshTokenAsync(string refreshToken)
        {
            return authService.GetTokenRefreshTokenAsync(refreshToken);
        }

        public Task<Login> GetTokenImplicitAsync(string state = "", string redirectionUri = "")
        {
            return authService.GetTokenImplicitAsync(state, redirectionUri);
        }
  
        public  Task<Login> GetCodeAuthorizationCodeAsync(string state = "", string redirectionUri = "")
        {

            return authService.GetCodeAuthorizationCodeAsync(state, redirectionUri);
        }
       
        public  Task<Login> GetTokenAuthorizationCodeAsync(string code, string redirectionUri = "")
        {
            return authService.GetTokenAuthorizationCodeAsync(code, redirectionUri);
        }
        public async Task<Login> ValidateToken()
        {
             return await authService.ValidateToken();
        }

        public async Task<SignUpResponse> SignUpAsync(Usuario user)
        {
            return await authService.SignUpAsync(user);
           
        }
    }

}
