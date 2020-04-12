using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EscapeRankUI.ViewModels.Salas
{
    public class SalaRankingViewModel : BaseViewModel
    {
        private ObservableCollection<Modelos.Partida> _partidas;

        public SalaRankingViewModel()
        {
            GetRanking();
        }

        public ObservableCollection<Modelos.Partida> Partidas
        {
            get { return _partidas; }
            set { SetProperty(ref _partidas, value); }
        }

        private void GetRanking()
        {
            List<Modelos.Partida> partidas = Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();

            Partidas = new ObservableCollection<Modelos.Partida>(partidas);
        }

    }
}
