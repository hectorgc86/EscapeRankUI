using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel lvm;

        public LoginPage()
        {
            lvm = new LoginViewModel();
            InitializeComponent();
            BindingContext = lvm;
        }
    }
}
