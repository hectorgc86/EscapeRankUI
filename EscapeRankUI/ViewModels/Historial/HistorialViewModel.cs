using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Historial
{
    public class HistorialViewModel : BaseViewModel
    {
        private ObservableCollection<Modelos.Partida> _partidas;

        public HistorialViewModel()
        {
            GetHistorial();
        }

        public ObservableCollection<Modelos.Partida> Partidas
        {
            get { return _partidas; }
            set { SetProperty(ref _partidas, value); }
        }

        private void GetHistorial()
        {
            if (Cargando)
                return;

            Cargando = true;

            List<Modelos.Partida> partidas = Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();

            Partidas = new ObservableCollection<Modelos.Partida>(partidas);
        }

    }
}
