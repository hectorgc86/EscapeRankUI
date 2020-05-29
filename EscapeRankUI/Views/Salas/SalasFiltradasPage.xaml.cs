using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class SalasFiltradasPage : ContentPage
    {
        private readonly SalasFiltradasViewModel sfvm;

        public SalasFiltradasPage(object filtro)
        {
            sfvm = new SalasFiltradasViewModel(filtro);
            InitializeComponent();
            BindingContext = sfvm;
        }
    }
}