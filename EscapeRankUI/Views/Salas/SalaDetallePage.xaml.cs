using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Perfil;
using System;
using EscapeRankUI.ViewModels.Salas;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views.Salas
{
    public partial class SalaDetallePage : ContentPage
    {
        public SalaDetalleViewModel sdvm;

        public SalaDetallePage(Sala salaSeleccionada)
        {
            sdvm = new SalaDetalleViewModel(salaSeleccionada);
            InitializeComponent();
            BindingContext = sdvm;
        }
    }
}