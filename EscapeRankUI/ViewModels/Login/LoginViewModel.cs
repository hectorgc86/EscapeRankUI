using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Servicios;
using EscapeRankUI.Views;
using Newtonsoft.Json;
using Plugin.FacebookClient;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IFacebookClient _servicioFacebook = CrossFacebookClient.Current;

        public Usuario Usuario { get; set; }
        public string Email { get; set; }
        public string Contrasenya { get; set; }
        private string ContrasenyaEncriptada { get; set; }


        public LoginViewModel()
        {
            App.CredencialesService.BorrarCredenciales();

            Usuario = new Usuario();
            LoginCommand = new Command(LoginAsync);
            RegistrarCommand = new Command(Registrar);
            FacebookLoginCommand = new Command(FacebookLogin);
            ResetPassCommand = new Command(ReestablecerPassAsync);
        }

        public Command LoginCommand { get; }
        public Command FacebookLoginCommand { get; }
        public Command RegistrarCommand { get; }
        public Command ResetPassCommand { get; }

        public async void LoginAsync()
        {
            Email = "hector@mail.com";
            Contrasenya = "tor";

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Contrasenya))
            {
                ContrasenyaEncriptada = Utils.CalcularMD5(Contrasenya);

                try
                {
                    Login login = await App.LoginService.GetLoginAsync(Email, ContrasenyaEncriptada);

                    if (login.UsuarioId != null)
                    {
                        await App.CredencialesService.GuardarCredenciales(Email, ContrasenyaEncriptada, login);
                        App.UsuarioPrincipal = await App.PerfilService.GetUsuarioAsync();
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error en la conexión", null, "Ok");
                    }
                }
                catch (HttpBadRequestException)
                {
                    await Application.Current.MainPage.DisplayAlert("Email o contraseña incorrecta", null, "Ok");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Deben rellenarse todos los campos", null, "Ok");
            }
        }

        private async void FacebookLogin()
        {
            try
            {
                if (_servicioFacebook.IsLoggedIn)
                {
                    _servicioFacebook.Logout();
                }

                async void userDataDelegate(object sender, FBEventArgs<string> e)
                {
                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<PerfilFacebook>(e.Data));
                            var socialLoginData = new Usuario
                            {
                                Id = DateTime.Now.Millisecond,
                                Avatar = facebookProfile.Picture.Data.Url,
                                Email = facebookProfile.Email,
                                Nombre = facebookProfile.FirstName
                            };

                            Application.Current.MainPage = new AppShell();
                            break;
                        case FacebookActionStatus.Canceled:
                            await Application.Current.MainPage.DisplayAlert("Facebook Auth", "Canceled", "Ok");
                            break;
                        case FacebookActionStatus.Error:
                            await Application.Current.MainPage.DisplayAlert("Facebook Auth", "Error", "Ok");
                            break;
                        case FacebookActionStatus.Unauthorized:
                            await Application.Current.MainPage.DisplayAlert("Facebook Auth", "Unauthorized", "Ok");
                            break;
                    }

                    _servicioFacebook.OnUserData -= userDataDelegate;
                }

                _servicioFacebook.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "picture", "gender", "last_name" };
                string[] fbPermisions = { "email" };
                await _servicioFacebook.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private async void ReestablecerPassAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ResetPassPage());
        }

        public async void Registrar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroPage());
        }
    }
}




