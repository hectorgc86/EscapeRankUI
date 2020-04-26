using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class AmigoDetalleViewModel : BaseViewModel
    {
        //Variables

        public Usuario _amigo;

        //Constructor

        public AmigoDetalleViewModel(Usuario amigoSeleccionado)
        {
            GetAmigo(amigoSeleccionado);
        }

        public Usuario Amigo
        {
            get { return _amigo; }
            set { SetProperty(ref _amigo, value); }
        }

        //Funciones

        private async void GetAmigo(Usuario amigoSeleccionado)
        {
            Amigo = await App.PerfilManager.GetAmigoAsync(amigoSeleccionado.Id);
        }
    }
}
