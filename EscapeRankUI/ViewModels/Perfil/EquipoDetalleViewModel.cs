using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
{
    public class EquipoDetalleViewModel : BaseViewModel
    {
        //Variables

        private Equipo _equipo;

        //Constructor

        public EquipoDetalleViewModel(Equipo equipoSeleccionado)
        {
            GetEquipo(equipoSeleccionado);
        }

        //Getters & Setters

        public Equipo Equipo
        {
            get { return _equipo; }
            set { SetProperty(ref _equipo, value); }
        }

        //Funciones

        private void GetEquipo(Equipo equipoSeleccionado)
        {
            Equipo = equipoSeleccionado;
        }

    }
}
