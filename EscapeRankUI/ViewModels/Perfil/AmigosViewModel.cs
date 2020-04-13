using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views.Perfil;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
{
    public class AmigosViewModel : BaseViewModel
    {
        //Variables

        private ObservableCollection<Usuario> _amigos;

        //Constructor

        public AmigosViewModel()
        {
            GetAmigos();
            VerAmigoCommand = new Command<Usuario>(VerAmigo);
        }

        //Getters & Setters

        public ICommand VerAmigoCommand { get; set; }

        public ObservableCollection<Usuario> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        //Funciones

        private async void GetAmigos()
        {
            List<Usuario> amigosCall = Servicios.ServicioFake.Usuarios[0].Amigos; //await App.ProfileManager.GetAmigos();

            Amigos = new ObservableCollection<Usuario>(amigosCall);
        }

        private async void VerAmigo(Usuario amigoSeleccionado)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AmigoDetallePage(amigoSeleccionado));
        }
    }
}
