using EscapeRankUI.Modelos;

namespace EscapeRankUI.ViewModels
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
