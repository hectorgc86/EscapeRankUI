using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class AmigoDetallePage : ContentPage
    {
        private readonly AmigoDetalleViewModel advm;

        public AmigoDetallePage(Amigo amigoSeleccionado)
        {
            advm = new AmigoDetalleViewModel(amigoSeleccionado);
            InitializeComponent();
            BindingContext = advm;
        }
    }
}