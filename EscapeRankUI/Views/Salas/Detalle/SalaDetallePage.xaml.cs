using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class SalaDetallePage : ContentPage
    {
        private readonly SalaDetalleViewModel sdvm;

        public SalaDetallePage(Sala salaSeleccionada)
        {
            sdvm = new SalaDetalleViewModel(salaSeleccionada);
            InitializeComponent();
            BindingContext = sdvm;
        }

        protected override void OnAppearing()
        {
            sdvm.GetInfo();
        }
    }
}