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
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
        public string RepContrasenya { get; set; }
        private string ContrasenyaEncriptada { get; set; }

        //Constructor

        public RegistroViewModel()
        {
            LoginCommand = new Command(Login);
            RegistrarCommand = new Command(Registrar);
        }

        public Command RegistrarCommand { get; set; }
        public Command LoginCommand { get; set; }

        //Funciones

        private async void Login(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public async void Registrar()
        {
                if (!string.IsNullOrEmpty(Nombre) &&
                    !string.IsNullOrEmpty(Email) &&
                    !string.IsNullOrEmpty(Contrasenya) &&
                    !string.IsNullOrEmpty(RepContrasenya) &&
                    Contrasenya == RepContrasenya)
                {
                    ContrasenyaEncriptada = Utils.CalcularMD5(Contrasenya);
                try
                {
                        Login login = await App.LoginService.PostRegistroAsync(Nombre, Email, ContrasenyaEncriptada);

                        if (login.UsuarioId != null)
                        {
                            await App.CredencialesService.GuardarCredenciales(Email, ContrasenyaEncriptada, login);
                            App.UsuarioPrincipal = await App.PerfilService.GetUsuarioAsync();
                            await Application.Current.MainPage.DisplayAlert("Usuario registrado con éxito", null, "Ok");
                            Application.Current.MainPage = new AppShell();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Error en la conexión", null, "Ok");
                        }
                    }
                    catch (HttpConflictException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ya existe un usuario registrado con ese Email", null, "Ok");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error validación", null, "Ok");
                }
            }

    }
}
