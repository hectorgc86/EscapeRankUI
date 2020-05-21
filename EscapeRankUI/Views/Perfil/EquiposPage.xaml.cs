using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
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

        protected async override void OnAppearing()
        {
            await evm.GetEquipos();
            evm.ModoEliminar = false;
        }
    }
}