using System;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Xamarin.Auth;

namespace EscapeRankUI.Servicios
{
    public interface ICredencialesService
    {
        int IdUsuario { get; }

        string Nombre { get; }

        string Contrasenya { get; }

        string TokenAcceso { get; }

        string TokenRefresco { get; }

        Task SaveCredentials(int IdUsuario, string nombre, string contrasenya, Login token);

        Task SaveToken(Login token);

        Task SaveAccount(Account account);

        Task DeleteCredentials();

        bool DoCredentialsExist();
    }
}
