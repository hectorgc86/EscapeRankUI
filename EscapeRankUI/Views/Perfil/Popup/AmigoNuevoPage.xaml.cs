using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class AmigoNuevoPage
    {
        private readonly AmigoNuevoViewModel anvm;

        public AmigoNuevoPage()
        {
            anvm = new AmigoNuevoViewModel();
            InitializeComponent();
            BindingContext = anvm;
        }
    }
}
