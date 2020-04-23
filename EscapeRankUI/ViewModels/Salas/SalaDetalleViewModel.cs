using System;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class SalaDetalleViewModel : BaseViewModel
    {
        private Sala _sala;

        public SalaDetalleViewModel(Sala salaSeleccionada)
        {
            ContactoSalaCommand = new Command(ContactarSala);
            GetInfo(salaSeleccionada);
        }

        public ICommand ContactoSalaCommand { get; set; }

        public Sala Sala
        {
            get { return _sala; }
            set { SetProperty(ref _sala, value); }
        }

        //Funciones

        private async void GetInfo(Sala salaSeleccionada)
        {
           Sala = await App.SalasManager.GetSalaAsync(salaSeleccionada.Id);
        }

        private void ContactarSala()
        {
            Launcher.OpenAsync(Sala.UrlReserva);
        }
    }
}
