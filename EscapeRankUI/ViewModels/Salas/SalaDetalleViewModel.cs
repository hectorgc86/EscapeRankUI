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

        public Command ContactoSalaCommand { get; }

        public Sala Sala
        {
            get { return _sala; }
            set { SetProperty(ref _sala, value); }
        }

        //Funciones

        private async void GetInfo(Sala salaSeleccionada)
        {
            Cargando = true;

            try
            {
                Sala = await App.SalasService.GetSalaAsync(salaSeleccionada.Id);
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

        private void ContactarSala()
        {
            Launcher.OpenAsync(Sala.UrlReserva);
        }
    }
}
