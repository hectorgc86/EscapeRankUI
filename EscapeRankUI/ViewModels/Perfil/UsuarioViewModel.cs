using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using EscapeRankUI.Estilos;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {

        //Variables

        private bool _modoOscuro;
        public Usuario Usuario { get; set; }
        public Command LogoutCommand { get; }

        //Constructor

        public UsuarioViewModel()
        {
            LogoutCommand = new Command(Logout);

            Usuario = App.UsuarioPrincipal;
        }

        //Getters & Setters

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

        //Funciones

        public async void Logout()
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Cerrar sesión", "¿Seguro de que desea cerrar sesión?", "Si", "No");

            if (respuesta)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
