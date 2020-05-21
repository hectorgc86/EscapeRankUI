using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Servicios;
using EscapeRankUI.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

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
            //Usuario = "hector@mail.com";
            //Contrasenya = "tor";

            if (!string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contrasenya))
            {
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




