using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class HistorialPage : ContentPage
    {
        private readonly HistorialViewModel hvm;

        public HistorialPage()
        {
            hvm = new HistorialViewModel();
            InitializeComponent();
            BindingContext = hvm;
        }

        protected override void OnAppearing()
        {
            hvm.GetHistorial();
        }
    }
}