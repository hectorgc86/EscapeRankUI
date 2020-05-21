using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views
{
    public partial class SalaDetallePage : ContentPage
    {
        public SalaDetalleViewModel sdvm;

        public SalaDetallePage(Sala salaSeleccionada)
        {
            sdvm = new SalaDetalleViewModel(salaSeleccionada);
            InitializeComponent();
            BindingContext = sdvm;
        }

        protected override void OnAppearing()
        {
            sdvm.GetInfo();
        }
    }
}