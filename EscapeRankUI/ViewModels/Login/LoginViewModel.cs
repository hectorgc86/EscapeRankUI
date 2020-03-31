using System;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Views.Login;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand ResetPassCommand { get; set; }
        public ICommand FacebookLoginCommand { get; set; }
        //public ICredentialsService storeService;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public LoginViewModel(INavigation navigation)
        {
           // storeService = App.CredentialsService;
           // storeService.DeleteCredentials();
           // Usuario = new Usuario();
            LoginCommand = new Command(Login);
            RegistrarCommand = new Command(Registrar);
            FacebookLoginCommand = new Command(FacebookLogin);
            ResetPassCommand = new Command(ReestablecerPassAsync);
            Navigation = navigation;
            
        }

        private async void ReestablecerPassAsync()
        {
            await Navigation.PushAsync(new ResetPassPage());
        }

        public async void Registrar()
        {
            await Navigation.PushAsync(new RegistroPage());
        }


        public void Login()
        {
            Application.Current.MainPage = new AppShell();
            /*
            Cargando = true;
            Title = string.Empty;
            try
            {
                if (Usuario != null)
                {
                    if (Usuario.Nombre != null)
                    {
                        if (Usuario.Contrasenya != null)
                        {
                            Login login = await App.AuthManager.GetLogin(Usuario.Nombre, Usuario.Contrasenya);
                            if (login != null && login.TokenRefresco != null && login.TokenAcceso != null)
                            {

                                await storeService.SaveCredentials(int.Parse(login.IdUsuario), Usuario.Nombre, Usuario.Contrasenya, login);

                             
                                App.UsuarioPrincipal = await App.ProfileManager.GetUsuario();

                                Application.Current.MainPage = new NavigationPage(new MainTabbedPage());
                            }
                            else
                            {
                                Message = "Usuario o contraseña incorrecta";
                            }
                            Cargando = false;
                        }
                        else
                        {
                            Cargando = false;
                            Message = "Contraseña requerida";
                        }
                    }
                    else
                    {
                        Cargando = false;
                        Message = "Contraseña inválida";
                    }

                }
                else
                {
                    Cargando = false;
                    Message = "Error Conectando al servidor";
                }
            }
            catch (Exception e)
            {
                Cargando = false;
                Debug.WriteLine("ERROR {0}", e.Message);
                await App.Current.MainPage.DisplayAlert("Error de conexión", e.Message, "Ok");
            }*/

        }
    


        public void FacebookLogin()
        {
            Debug.WriteLine("Has hecho Login mediante facebook");
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                  //  clientId = Constants.GoogleiOSClientId;
                  //  redirectUri = Constants.GoogleiOSRedirectUrl;
                    break;

                case Device.Android:
                  //  clientId = Constants.GoogleAndroidClientId;
                  //  redirectUri = Constants.GoogleAndroidRedirectUrl;
                    break;
            }
           /* 
            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.Scope,
                new Uri(Constants.GoogleAuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.GoogleTokenAccesoUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
            */
        }

        /*
        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Usuario user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri(Constants.GoogleUserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<Usuario>(userJson);
                }

                await storeService.SaveAccount(e.Account);
                Settings.IsLoggedIn = true;
                await Navigation.PushAsync(new EscapePage());
                //  await DisplayAlert("Email address", user.Email, "OK");
            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }
        */
    }
}




