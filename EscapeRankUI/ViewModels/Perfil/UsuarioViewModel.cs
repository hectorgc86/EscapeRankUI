using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views.Login;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
{
    public class UsuarioViewModel : BaseViewModel
    {

    //Variables

        private bool _modoOscuro;
        private Usuario _usuario;

    //Constructor

        public UsuarioViewModel()
        {
            LogoutCommand = new Command(Logout);

            GetPerfil();
        }

    //Getters & Setters

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public bool ModoOscuro
        {
            get { return _modoOscuro; }
            set
            {
                _modoOscuro = value;

                if (_modoOscuro)
                {
                    Application.Current.Resources.Clear();
                    Application.Current.Resources = new Oscuro();
                }
                else
                {
                    Application.Current.Resources.Clear();
                    Application.Current.Resources = new Claro();
                }
            }
        }

        public ICommand LogoutCommand { get; set; }

    //Funciones

        private async void GetPerfil()
        {
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
