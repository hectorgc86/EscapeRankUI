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

        public Amigo _amigo;

        //Constructor

        public AmigoDetalleViewModel(Amigo amigoSeleccionado)
        {
            GetAmigo(amigoSeleccionado);
        }

        public Amigo Amigo
        {
            get { return _amigo; }
            set { SetProperty(ref _amigo, value); }
        }

        //Funciones

        public async void GetAmigo(Amigo amigoSeleccionado)
        {
            Cargando = true;

            try
            {
                Amigo = await App.PerfilService.GetAmigoAsync(amigoSeleccionado.Id);
            }
            catch (HttpUnauthorizedException)
            {
                ErrorCredenciales();
            }
            finally
            {
                Cargando = false;
            }
        }
    }
}
