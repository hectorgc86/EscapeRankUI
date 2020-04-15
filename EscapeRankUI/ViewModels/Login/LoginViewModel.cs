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
        public ICredencialesService storeService;
        public IFacebookClient _servicioFacebook = CrossFacebookClient.Current;
        public Usuario Usuario { get; set; }
        public LoginViewModel()
        {
            storeService = App.CredencialesService;
            storeService.DeleteCredentials();
            Usuario = new Usuario();
            LoginCommand = new Command(LoginAsync);
            RegistrarCommand = new Command(Registrar);
            FacebookLoginCommand = new Command(FacebookLogin);
            ResetPassCommand = new Command(ReestablecerPassAsync);
        }

        public ICommand LoginCommand { get; set; }
        public ICommand FacebookLoginCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand ResetPassCommand { get; set; }


        public async void LoginAsync()
        {
            Usuario.Email = "hector@mail.com";
            Usuario.Contrasenya = "tor";

            try
            {
                if (Usuario != null)
                {
                    if (Usuario.Email != null)
                    {
                        if (Usuario.Contrasenya != null)
                        {
                            Login login = await App.LoginManager.GetLogin(Usuario.Email, Usuario.Contrasenya);
                            if (login != null && login.TokenRefresco != null && login.TokenAcceso != null)
                            {
                                await storeService.SaveCredentials(int.Parse(login.IdUsuario), Usuario.Nombre, Usuario.Contrasenya, login);
                             
                                App.UsuarioPrincipal = await App.PerfilManager.GetUsuario();

                                Application.Current.MainPage = new AppShell();
                            }
                            else
                            {
                               await Application.Current.MainPage.DisplayAlert("Email o contraseña incorrecta",null, "Ok");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Contraseña requerida", null, "Ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Contraseña inválida", null, "Ok");
                    }

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error Conectando al servidor", null, "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR {0}", e.Message);
                await Application.Current.MainPage.DisplayAlert("Error de conexión", e.Message, "Ok");
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

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
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
                };

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




