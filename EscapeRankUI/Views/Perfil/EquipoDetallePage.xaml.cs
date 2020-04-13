using System;
using System.Collections.Generic;
using EscapeRankUI.Modelos;
using EscapeRankUI.ViewModels.Perfil;
using Xamarin.Forms;

namespace EscapeRankUI.Views.Perfil
{
    public partial class EquipoDetallePage : ContentPage
    {
        private EquipoDetalleViewModel edvm;

        public EquipoDetallePage(Equipo equipoSeleccionado)
        {
            edvm = new EquipoDetalleViewModel(equipoSeleccionado);
            InitializeComponent();
            BindingContext = edvm;
        }
    }
}
