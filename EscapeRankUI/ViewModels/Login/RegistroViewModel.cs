using System;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Views.Login;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Login
{
    public class RegistroViewModel : BaseViewModel
    {
        #region Commands
        public ICommand RegistrarCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        //public ICredentialsService storeService;
        #endregion

        #region Properties
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        #endregion

        public RegistroViewModel(INavigation navigation)
        {
            //storeService = App.CredentialsService;
            //storeService.DeleteCredentials();
            LoginCommand = new Command(Login);
            RegistrarCommand = new Command(Registrar);
            Navigation = navigation;
        }

        private async void Login(object obj)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        public void Registrar()
        {
            Debug.WriteLine("Has hecho Registrar");
            Cargando = true;
            /*
            // Sign up logic goes here

            var signUpSucceeded = await AreDetailsValid(User);
            if (signUpSucceeded.Status=="ok")
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {

                    LoginResponse login = await App.AuthManager.GetLogin(User.Nombre, User.Contrasenya);
                    if (login.Estado == "ok" && login.Datos.TokenRefresco != null && login.Datos.TokenAcceso != null)
                    {
                        //await storeService.SaveCredentials(login.Data.IdUsuario, User.Username, User.Password, login);
                        App.UsuarioPrincipal = await App.ProfileManager.GetUsuario();
                        Application.Current.MainPage = new NavigationPage(new MainTabbedPage());
                    }
                    // App.IsUserLoggedIn = true;
                   // Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                   //await Navigation.PopToRootAsync();
                }
            }
            else
            {
                Message = "Fallo en registro. "+signUpSucceeded.Result;
            }

            Cargando = false;

            }
            catch (Exception e)
            {
                Cargando = false;
                Debug.WriteLine("ERROR {0}", e.Message);
                await App.Current.MainPage.DisplayAlert("Error de conexión", e.Message, "Ok");
            }
            */
        }
        /*
        async Task<SignUpResponse> AreDetailsValid(Usuario user)
        {
            var signUpResponse = new SignUpResponse();
            if (user == null)
            {
                signUpResponse.Status = "error";
                signUpResponse.Result = "Error conectando al servidor.";
            }else if (!string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Contrasenya) &&
                !string.IsNullOrWhiteSpace(user.Nombre) &&
                !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"))
            {
                signUpResponse= await App.AuthManager.SignUpAsync(user);

            }
            else
            {
                signUpResponse.Status = "error";
                signUpResponse.Result = "e-Mail y Contraseña requeridos.";
            }
            return signUpResponse;
        }*/
    }
}
