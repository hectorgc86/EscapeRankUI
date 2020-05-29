using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class SalasPage : ContentPage
    {
        private readonly SalasViewModel svm;

        public SalasPage()
        {
            svm = new SalasViewModel();
            InitializeComponent();
            BindingContext = svm;
        }

        protected override void OnAppearing()
        {
            svm.GetSalasPromocionadas();
        }
    }
}