using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class EquipoDetalleViewModel : BaseViewModel
    {
        //Variables

        public Equipo Equipo { get; set; }

        private ObservableCollection<Usuario> _miembrosEquipo;
        private ObservableCollection<Partida> _partidasEquipo;

        //Constructor

        public EquipoDetalleViewModel(Equipo equipoSeleccionado)
        {
            Equipo = equipoSeleccionado;

            GetIntegrantes();
            GetPartidas();
        }

        //Getters & Setters

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

        //Funciones

        private async void GetIntegrantes()
        {
            List<Usuario> miembrosCall = await App.PerfilManager.GetMiembrosEquipoAsync(Equipo.Id);

            MiembrosEquipo = new ObservableCollection<Usuario>(miembrosCall);
        }

        private async void GetPartidas()
        {
            List<Partida> partidasCall = await App.PerfilManager.GetPartidasEquipoAsync(Equipo.Id);

            PartidasEquipo = new ObservableCollection<Partida>(partidasCall);
        } 
    }
}
