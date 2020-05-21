using System;
using System.Threading.Tasks;
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
            SalaSeleccionada = salaSeleccionada;

            ContactoSalaCommand = new Command(async () => await ContactarSalaAsync());
        }

        public Command ContactoSalaCommand { get; }

        public Sala Sala
        {
            get { return _sala; }
            set { SetProperty(ref _sala, value); }
        }

        //Funciones

        public async void GetInfo()
        {
            Cargando = true;

            try
            {
                Sala = await App.SalasService.GetSalaAsync(SalaSeleccionada.Id);
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

        private async Task ContactarSalaAsync()
        {
            await Launcher.OpenAsync(Sala.UrlReserva);
        }
    }
}
