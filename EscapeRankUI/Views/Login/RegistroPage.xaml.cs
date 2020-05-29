using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class RegistroPage : ContentPage
    {
        private readonly RegistroViewModel rvm;

        public RegistroPage()
        {
            rvm = new RegistroViewModel();
            InitializeComponent();
            BindingContext = rvm;
        }

        void Entry_Focused(object sender, FocusEventArgs e)
        {
            EntryNacimiento.Placeholder = "Fecha nacimiento (dd/mm/yyyy)";
        }

        void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            EntryNacimiento.Placeholder = "Fecha nacimiento";
        }
    }
}
