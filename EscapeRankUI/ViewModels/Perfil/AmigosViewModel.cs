using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
{
    public class AmigosViewModel : BaseViewModel
    {
        private ObservableCollection<Usuario> _amigos;

        public AmigosViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetAmigos();
        }

        public ObservableCollection<Usuario> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        private async void GetAmigos()
        {
            if (Cargando)
                return;

            Cargando = true;

            List<Usuario> amigosCall = Servicios.ServicioFake.Usuarios[0].Amigos; //await App.ProfileManager.GetAmigos();

            Amigos = new ObservableCollection<Usuario>(amigosCall);
        }
    }
}
