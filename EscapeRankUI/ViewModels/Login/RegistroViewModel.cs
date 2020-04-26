using System;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Servicios;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {

    //Variables

        public ICredencialesService storeService;

    //Constructor

        public RegistroViewModel()
        {
            storeService = App.CredencialesService;
            storeService.DeleteCredentials();
            LoginCommand = new Command(Login);
            RegistrarCommand = new Command(Registrar);
        }

        //Getters & Setters

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
        public string RepContrasenya { get; set; }
        public Command RegistrarCommand { get; set; }
        public Command LoginCommand { get; set; }

    //Funciones

        private async void Login(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public async void Registrar()
        {
            try
            {
                if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Contrasenya) && !string.IsNullOrEmpty(RepContrasenya) && Contrasenya == RepContrasenya)
                {
                    Login login = await App.LoginManager.PostRegistroAsync(Nombre, Email, Contrasenya);

                    if (login != null && login.TokenRefresco != null && login.TokenAcceso != null)
                    {
                        await storeService.SaveCredentials(int.Parse(login.IdUsuario), Email, Contrasenya, login);

                        App.UsuarioPrincipal = await App.PerfilManager.GetUsuarioAsync();

                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error registrando usuario", null, "Ok");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error validación", null, "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR {0}", e.Message);
                await Application.Current.MainPage.DisplayAlert("Error de conexión", e.Message, "Ok");
            }
        }

    }
}
