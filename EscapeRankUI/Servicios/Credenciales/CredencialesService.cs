using System.Threading.Tasks;
using EscapeRankUI.Estilos;
using EscapeRankUI.Modelos;
using Xamarin.Essentials;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

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

        public async Task<string> GetTema()
        {
            return await SecureStorage.GetAsync("Tema");
        }

        public async Task GuardarCredenciales(string usuario, string contrasenya, Login login)
        {
            await SecureStorage.SetAsync("UsuarioId", login.UsuarioId);
            await SecureStorage.SetAsync("Usuario", usuario);
            await SecureStorage.SetAsync("Contrasenya", contrasenya);
            await SecureStorage.SetAsync("TokenAcceso", login.TokenAcceso);
        }

        public async Task GuardarTema(string tema)
        {
            await SecureStorage.SetAsync("Tema", tema);
        }

        public void BorrarCredenciales()
        {
            SecureStorage.Remove("UsuarioId");
            SecureStorage.Remove("Usuario");
            SecureStorage.Remove("Contrasenya");
            SecureStorage.Remove("TokenAcceso");
        }

        public async Task<bool> ComprobarCredenciales()
        {
            bool existen;

            string usuario = await SecureStorage.GetAsync("Usuario");
            string contrasenya = await SecureStorage.GetAsync("Contrasenya");
            string tema = await SecureStorage.GetAsync("Tema");

            if (!string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(contrasenya))
            {
                Login login = await App.LoginService.GetLoginAsync(usuario, contrasenya);

                if (login.UsuarioId != null)
                {
                    await GuardarCredenciales(usuario, contrasenya, login);
                }

                existen = true;
            }
            else
            {
                existen = false;
            }

            if (tema == "Oscuro")
            {
                Application.Current.Resources = new Oscuro();
            }

            return existen;
        }
    }
}
