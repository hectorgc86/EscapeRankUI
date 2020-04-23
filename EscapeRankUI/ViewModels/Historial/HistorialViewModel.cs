using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class HistorialViewModel : BaseViewModel
    {
        private ObservableCollection<Partida> _partidas;

        public HistorialViewModel()
        {
            GetHistorial();
        }

        public ObservableCollection<Partida> Partidas
        {
            get { return _partidas; }
            set { SetProperty(ref _partidas, value); }
        }

        private async void GetHistorial()
        {
            List<Partida> partidas = await App.HistorialManager.GetHistorialAsync(App.UsuarioPrincipal.Id);
            //Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();

            Partidas = new ObservableCollection<Partida>(partidas);
        }

    }
}
