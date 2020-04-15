using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
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
            Usuario = App.UsuarioPrincipal; //Servicios.ServicioFake.Usuarios[0];
        }

        public async void Logout()
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Cerrar sesión", "¿Seguro de que desea cerrar sesión?","Si","No");
            if (respuesta)
            {
                await App.CredencialesService.DeleteCredentials();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
