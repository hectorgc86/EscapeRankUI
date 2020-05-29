using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class ResetPassPage : ContentPage
    {
        private readonly ResetPassViewModel rpvm;

        public ResetPassPage()
        {
            rpvm = new ResetPassViewModel();
            InitializeComponent();
            BindingContext = rpvm;
        }
    }
}
