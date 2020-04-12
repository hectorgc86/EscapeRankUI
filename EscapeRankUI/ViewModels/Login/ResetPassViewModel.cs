using System;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Views.Login;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Login
{
    public class ResetPassViewModel : BaseViewModel
    {
        public ResetPassViewModel()
        {
            // storeService = App.CredentialsService;
            // storeService.DeleteCredentials();
            // Usuario = new Usuario();
            ResetPassCommand = new Command(ReestablecerPass);
            RegistrarCommand = new Command(Registrar);
            
        }

        public ICommand ResetPassCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }

        private void ReestablecerPass()
        {
            Debug.WriteLine("Has hecho reset");
        }
        public async void Registrar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroPage());
        }
    }
}




