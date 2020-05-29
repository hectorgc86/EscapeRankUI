using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class EquipoDetallePage : ContentPage
    {
        private readonly EquipoDetalleViewModel edvm;

        public EquipoDetallePage(Equipo equipoSeleccionado)
        {
            edvm = new EquipoDetalleViewModel(equipoSeleccionado);
            InitializeComponent();
            BindingContext = edvm;
        }
    }
}
