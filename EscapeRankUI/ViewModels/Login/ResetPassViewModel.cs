using System;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class ResetPassViewModel : BaseViewModel
    {
        public Command ResetPassCommand { get; }
        public Command RegistrarCommand { get; }

        public ResetPassViewModel()
        {
            ResetPassCommand = new Command(ReestablecerPass);
            RegistrarCommand = new Command(Registrar);
        }

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




