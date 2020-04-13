using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
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

        private void GetAmigo(Usuario amigoSeleccionado)
        {
            Amigo = amigoSeleccionado;
        }

    }
}
