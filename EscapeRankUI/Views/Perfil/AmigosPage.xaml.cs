using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class AmigosPage : ContentPage
    {
        private readonly AmigosViewModel avm;

        public AmigosPage()
        {
            avm = new AmigosViewModel();
            InitializeComponent();
            BindingContext = avm;
        }

        protected override void OnAppearing()
        {
            avm.GetAmigos();
            avm.ModoEliminar = false;
        }
    }
}