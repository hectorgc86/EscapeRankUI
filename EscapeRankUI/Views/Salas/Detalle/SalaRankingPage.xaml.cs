using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views
{
    public partial class SalaRankingPage : ContentPage
    {
        public SalaRankingViewModel srvm;

        public SalaRankingPage(Sala salaSeleccionada)
        {
            srvm = new SalaRankingViewModel(salaSeleccionada);
            InitializeComponent();
            BindingContext = srvm;
        }

    }
}