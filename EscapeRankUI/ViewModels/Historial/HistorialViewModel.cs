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

        public ObservableCollection<Partida> Partidas
        {
            get { return _partidas; }
            set { SetProperty(ref _partidas, value); }
        }

        public async void GetHistorial()
        {
            Cargando = true;

            try
            {
                List<Partida> partidas = await App.HistorialService.GetHistorialAsync(App.UsuarioPrincipal.Id);
                //Servicios.ServicioFake.Equipos.SelectMany(p=>p.Partidas).Distinct().ToList();
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
