using System;
using System.Linq;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using Xamarin.Auth;
using Xamarin.Essentials;

namespace EscapeRankUI.Servicios
{
    public class CredencialesService : ICredencialesService
    {
        public async Task<string> GetUsuarioId()
        {
            return await SecureStorage.GetAsync("UsuarioId");
        }

        public async Task<string> GetToken()
        {
            return await SecureStorage.GetAsync("TokenAcceso");
        }

        public async Task GuardarCredenciales(string email, string contrasenya, Login login)
        {
            await SecureStorage.SetAsync("UsuarioId", login.UsuarioId);
            await SecureStorage.SetAsync("Email", email);
            await SecureStorage.SetAsync("Contrasenya", contrasenya);
            await SecureStorage.SetAsync("TokenAcceso", login.TokenAcceso);
        }

        public void BorrarCredenciales()
        {
            SecureStorage.RemoveAll();
        }

        public async Task<bool> ComprobarCredenciales()
        {
            bool existen;

            string email = await SecureStorage.GetAsync("Email");
            string contrasenya = await SecureStorage.GetAsync("Contrasenya");

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(contrasenya))
            {
                Login login = await App.LoginService.GetLoginAsync(email, contrasenya);

                if (login.UsuarioId != null)
                {
                    await GuardarCredenciales(email, contrasenya, login);
                }

                existen = true;
            }
            else
            {
                existen = false;
            }

            return existen;
        }
    }
}
