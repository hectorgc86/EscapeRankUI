using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class SalaRankingPage : ContentPage
    {
        private readonly SalaRankingViewModel srvm;

        public SalaRankingPage(Sala salaSeleccionada)
        {
            srvm = new SalaRankingViewModel(salaSeleccionada);
            InitializeComponent();
            BindingContext = srvm;
        }

    }
}