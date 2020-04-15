using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.ViewModels
{
    public class SalaRankingViewModel : BaseViewModel
    {
        private ObservableCollection<Partida> _partidas;

        public SalaRankingViewModel()
        {
            GetRanking();
        }

        public ObservableCollection<Partida> Partidas
        {
            get { return _partidas; }
            set { SetProperty(ref _partidas, value); }
        }

        private void GetRanking()
        {
            List<Partida> partidas = Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();

            Partidas = new ObservableCollection<Partida>(partidas);
        }

    }
}
