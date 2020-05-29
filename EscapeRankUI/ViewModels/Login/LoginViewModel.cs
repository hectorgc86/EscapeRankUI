using System.Net.Http;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public string Usuario { get; set; }
        public string Contrasenya { get; set; }
        private string ContrasenyaEncriptada { get; set; }


        public LoginViewModel()
        {
            App.CredencialesService.BorrarCredenciales();

            LoginCommand = new Command(LoginAsync);
            RegistrarCommand = new Command(Registrar);
            FacebookLoginCommand = new Command(FacebookLogin);
            ResetPassCommand = new Command(ReestablecerPassAsync);
        }

        public Command LoginCommand { get; }
        public Command FacebookLoginCommand { get; }
        public Command RegistrarCommand { get; }
        public Command ResetPassCommand { get; }

        private async void LoginAsync()
        {
            if (!string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contrasenya))
            {
                Cargando = true;

                ContrasenyaEncriptada = Utils.CalcularMD5(Contrasenya);

                try
                {
                    Login login = await App.LoginService.GetLoginAsync(Usuario, ContrasenyaEncriptada);

                    if (login.UsuarioId != null)
                    {
                        await App.CredencialesService.GuardarCredenciales(Usuario, ContrasenyaEncriptada, login);
                        App.UsuarioPrincipal = await App.PerfilService.GetUsuarioAsync();
                        Application.Current.MainPage = new AppShell();
                    }
                }
                catch (HttpBadRequestException)
                {
                    await Application.Current.MainPage.DisplayAlert("Usuario o contraseña incorrectos", null, "Ok");
                }
                catch (HttpRequestException)
                {
                    await Application.Current.MainPage.DisplayAlert("Error en la conexión", null, "Ok");
                }
                finally
                {
                    Cargando = false;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Deben rellenarse todos los campos", null, "Ok");
            }
        }

        private async void FacebookLogin()
        {
            await Application.Current.MainPage.DisplayAlert("Esta función estará disponible en versiones futuras", null, "Ok");
        }

        private async void ReestablecerPassAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ResetPassPage());
        }

        private async void Registrar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroPage());
        }
    }
}




