using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface ILoginService
    {
        Task<Login> GetLoginAsync(string email, string contrasenya);

        Task<Login> PostRegistroAsync(string nombre, string email, string contrasenya);

        Task<Login> GetTokenClientCredentialsAsync();

        Task<Login> GetTokenRefreshTokenAsync(string refresh_token);

        Task<Login> GetTokenImplicitAsync(string state = "", string redirectionUri = "");

        Task<Login> GetCodeAuthorizationCodeAsync(string state = "", string redirectionUri = "");

        Task<Login> GetTokenAuthorizationCodeAsync(string code, string redirectionUri = "");

        Task<Login> ValidateToken();
    }
}