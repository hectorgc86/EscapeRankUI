using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Salas
{
    public class SalaDetalleViewModel : BaseViewModel
    {
        private Sala _sala;

        public SalaDetalleViewModel(Sala salaSeleccionada)
        {
            GetSala(salaSeleccionada);
        }

        public Sala Sala
        {
            get { return _sala; }
            set { SetProperty(ref _sala, value); }
        }

        private async void GetSala(Sala salaSeleccionada)
        {
            Sala = salaSeleccionada;
        }
    }
}
