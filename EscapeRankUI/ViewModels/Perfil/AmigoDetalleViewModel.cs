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

        private Usuario _amigo;

        //Constructor

        public AmigoDetalleViewModel(Usuario amigoSeleccionado)
        {
            GetAmigo(amigoSeleccionado);
        }

        //Getters & Setters

        public Usuario Amigo
        {
            get { return _amigo; }
            set { SetProperty(ref _amigo, value); }
        }

        //Funciones

        private async void GetAmigo(Usuario amigoSeleccionado)
        {
            Amigo = await App.PerfilManager.GetAmigoAsync(amigoSeleccionado.Id);

            if (Amigo.Nacido != null)
            {
                Amigo.Edad = Utils.CalcularEdad(Amigo.Nacido.Value);
            }
        }

    }
}
