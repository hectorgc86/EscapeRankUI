using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Perfil;

namespace EscapeRankUI.Views.Perfil
{
    public partial class EquiposPage : ContentPage
    {
        public EquiposViewModel evm;

        public EquiposPage()
        {
            evm = new EquiposViewModel();
            InitializeComponent();
            BindingContext = evm;
        }
    }
}