using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class EquipoDetalleViewModel : BaseViewModel
    {
        private ObservableCollection<Usuario> _miembrosEquipo;
        private ObservableCollection<Partida> _partidasEquipo;

        public Equipo Equipo { get; set; }

        public EquipoDetalleViewModel(Equipo equipoSeleccionado)
        {
            Equipo = equipoSeleccionado;

                GetIntegrantes();
                GetPartidas();
        }

        public ObservableCollection<Usuario> MiembrosEquipo
        {
            get { return _miembrosEquipo; }
            set { SetProperty(ref _miembrosEquipo, value); }
        }

        public ObservableCollection<Partida> PartidasEquipo
        {
            get { return _partidasEquipo; }
            set { SetProperty(ref _partidasEquipo, value); }
        }

        private async void GetIntegrantes()
        {
            Cargando = true;

            try
            {
                List<Usuario> miembrosCall = await App.PerfilService.GetMiembrosEquipoAsync(Equipo.Id);
                MiembrosEquipo = new ObservableCollection<Usuario>(miembrosCall);
            }
            catch (HttpUnauthorizedException)
            {
                ErrorCredenciales();
            }
        }

        private async void GetPartidas()
        {
            try
            {
                List<Partida> partidasCall = await App.PerfilService.GetPartidasEquipoAsync(Equipo.Id);
                PartidasEquipo = new ObservableCollection<Partida>(partidasCall);
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
