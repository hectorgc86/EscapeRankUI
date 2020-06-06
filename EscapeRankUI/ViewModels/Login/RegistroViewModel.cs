using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        public string Nombre { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contrasenya { get; set; }
        public string Nacido { get; set; }
        public string RepContrasenya { get; set; }
        private string ContrasenyaEncriptada { get; set; }

        public RegistroViewModel()
        {
            LoginCommand = new Command(Login);
            RegistrarCommand = new Command(Registrar);
        }

        public Command RegistrarCommand { get; set; }
        public Command LoginCommand { get; set; }

        private async void Login()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async void Registrar()
        {
            if (!await ValidarRegistroAsync())
            {
                ContrasenyaEncriptada = Utils.CalcularMD5(Contrasenya);


                DateTime? nacidoFormateado = null;

                if (!string.IsNullOrEmpty(Nacido))
                {
                    nacidoFormateado = DateTime.ParseExact(Nacido, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                Cargando = true;

                try
                {
                    Usuario usuario = new Usuario {
                        Nick = Nick,
                        Email = Email,
                        Contrasenya = ContrasenyaEncriptada,
                        Perfil = new Perfil {
                            Nombre = Nombre,
                            Telefono = Telefono,
                            Nacido = nacidoFormateado
                        }
                    };

                    Login login = await App.LoginService.PostRegistroAsync(usuario);

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
                    await Application.Current.MainPage.DisplayAlert("Ya existe un usuario registrado con ese nombre de usuario o e-mail", null, "Ok");
                }
                finally
                {
                    Cargando = false;
                }
            }
        }

        //Función de validación de campos del formulario de registro

        private async Task<bool> ValidarRegistroAsync()
        {
            string cadenaError = "";
            bool error = false;

            if (string.IsNullOrEmpty(Nick) ||
                    string.IsNullOrEmpty(Email) ||
                    string.IsNullOrEmpty(Contrasenya) ||
                    string.IsNullOrEmpty(RepContrasenya))
            {
                cadenaError += "Debe rellenar todos los campos obligatorios";
                error = true;
            }
            else
            {
                if (!Regex.IsMatch(Email, Utils.RegexEmail , RegexOptions.IgnoreCase))
                {
                    cadenaError += "El email no tiene una estructura correcta\n";
                    error = true;
                }

                if (!string.IsNullOrEmpty(Nacido) && !Regex.IsMatch(Nacido, Utils.RegexNacido))
                {
                    cadenaError += "La fecha de nacimiento no tiene una estructura correcta\n";
                    error = true;
                }

                if (Contrasenya != RepContrasenya)
                {
                    cadenaError += "Las contraseñas no coinciden\n";
                    error = true;
                }
            }

            if (error)
            {
                await Application.Current.MainPage.DisplayAlert("Error validación", cadenaError, "Ok");
            }

            return error;
        }
    }
}
