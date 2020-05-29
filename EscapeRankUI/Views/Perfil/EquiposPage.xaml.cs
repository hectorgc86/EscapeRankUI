using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class EquiposPage : ContentPage
    {
        private readonly EquiposViewModel evm;

        public EquiposPage()
        {
            evm = new EquiposViewModel();
            InitializeComponent();
            BindingContext = evm;
        }

        protected async override void OnAppearing()
        {
            await evm.GetEquipos();
            evm.ModoEliminar = false;
        }
    }
}