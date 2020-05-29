using Xamarin.Forms;
using EscapeRankUI.ViewModels;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Views
{
    public partial class UsuarioPage : ContentPage
    {
        private readonly UsuarioViewModel uvm;

        public UsuarioPage()
        {
            uvm = new UsuarioViewModel();
            InitializeComponent();
            BindingContext = uvm;
        }
    }
}