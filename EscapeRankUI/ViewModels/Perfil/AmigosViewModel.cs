using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class AmigosViewModel : BaseViewModel
    {
        private ObservableCollection<Usuario> _amigos;

        public Command VerAmigoCommand { get; }

        //Constructor

        public AmigosViewModel()
        {
            VerAmigoCommand = new Command<Usuario>(VerAmigo);

            GetAmigos();
        }


        public ObservableCollection<Usuario> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        //Funciones

        private async void GetAmigos()
        {
            List<Usuario> amigosCall = await App.PerfilManager.GetAmigosAsync(); //Servicios.ServicioFake.Usuarios[0].Amigos; 
            Amigos = new ObservableCollection<Usuario>(amigosCall);
        }

        private async void VerAmigo(Usuario amigoSeleccionado)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AmigoDetallePage(amigoSeleccionado));
        }
    }
}
