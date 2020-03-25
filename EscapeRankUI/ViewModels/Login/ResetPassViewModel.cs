using System;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Views.Login;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Login
{
    public class ResetPassViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ResetPassCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        #endregion

        #region Properties
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        #endregion

        public ResetPassViewModel(INavigation navigation)
        {
            // storeService = App.CredentialsService;
            // storeService.DeleteCredentials();
            // Usuario = new Usuario();
            ResetPassCommand = new Command(ReestablecerPass);
            RegistrarCommand = new Command(Registrar);
            Navigation = navigation;
            
        }
        private void ReestablecerPass()
        {
            Debug.WriteLine("Has hecho reset");
        }
        public async void Registrar()
        {
            await Navigation.PushAsync(new RegistroPage());
        }
    }
}




