using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class MuroPage : ContentPage
    {
        private readonly MuroViewModel mvm;

        public MuroPage()
        {
            mvm = new MuroViewModel();
            InitializeComponent();
            BindingContext = mvm;
        }

        protected override void OnAppearing()
        {
            mvm.GetNoticias();
        }
    }
}