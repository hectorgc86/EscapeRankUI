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
            int offset = 0;

            Cargando = true;

            try
            {
                List<Partida> partidas = (await App.SalasService.GetPartidasSalaAsync(salaSeleccionada.Id, offset))
                    .OrderBy(d => d.DuracionPartida).ToList();
                //Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();

                for (int i = 0; i < partidas.Count; i++)
                {
                    partidas[i].PosicionRanking = i + 1;
                }

                Partidas = new ObservableCollection<Partida>(partidas);
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
