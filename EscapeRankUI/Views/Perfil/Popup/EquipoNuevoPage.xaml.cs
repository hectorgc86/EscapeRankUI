using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class EquipoNuevoPage
    {
        private readonly EquipoNuevoViewModel envm;

        public EquipoNuevoPage()
        {
            envm = new EquipoNuevoViewModel();
            InitializeComponent();
            BindingContext = envm;
        }
    }
}
