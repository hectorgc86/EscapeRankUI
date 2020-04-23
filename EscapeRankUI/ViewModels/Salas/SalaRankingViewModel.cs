using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.ViewModels
{
    public class SalaRankingViewModel : BaseViewModel
    {
        private ObservableCollection<Partida> _partidas;

        public SalaRankingViewModel(Sala salaSeleccionada)
        {
            GetRanking(salaSeleccionada);
        }

        public ObservableCollection<Partida> Partidas
        {
            get { return _partidas; }
            set { SetProperty(ref _partidas, value); }
        }

        private async void GetRanking(Sala salaSeleccionada)
        {
            List<Partida> partidas = await App.SalasManager.GetPartidasSalaAsync(salaSeleccionada.Id);
            //Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();

            foreach (Partida p in partidas)
            {
                p.DuracionPartida = new TimeSpan(p.Horas, p.Minutos, p.Segundos);
            }

            List<Partida> partidasOrdenadas = partidas.OrderBy(d => d.DuracionPartida).ToList();

            for(int i = 0;i < partidasOrdenadas.Count; i++)
            {
                partidasOrdenadas[i].PosicionRanking = i + 1;
            }

            Partidas = new ObservableCollection<Partida>(partidasOrdenadas);
        }
    }
}
