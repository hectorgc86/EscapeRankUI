using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views.Login;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
{
    public class UsuarioViewModel : BaseViewModel
    {
        private Usuario _usuario;
        public ICommand LogoutCommand { get; set; }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public UsuarioViewModel(INavigation navigation)
        {
            LogoutCommand = new Command(Logout);
            Navigation = navigation;

            GetPerfil();
        }

        private async void GetPerfil()
        {
        //    if (Cargando)
          //      return;

            //Cargando = true;

            Usuario = Servicios.ServicioFake.Usuarios[0]; //await App.ProfileManager.GetPerfil();
        }

        public async void Logout()
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Cerrar sesión", "¿Seguro de que desea cerrar sesión?","Si","No");
            if (respuesta)
            {
                //await App.CredentialsService.DeleteCredentials();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
