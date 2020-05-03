using System;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Xamarin.Auth;

namespace EscapeRankUI.Servicios
{
    public interface ICredencialesService
    {
        Task<string> GetUsuarioId();

        Task<string> GetToken();

        Task GuardarCredenciales(string email, string contrasenya, Login login);

        void BorrarCredenciales();

        Task<bool> ComprobarCredenciales();
    }
}
