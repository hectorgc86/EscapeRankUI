using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views
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
