using EscapeRankUI.ViewModels.Salas;
using Xamarin.Forms;

namespace EscapeRankUI.Views.Salas
{
    public partial class SalaRankingPage : ContentPage
    {
        public SalaRankingViewModel srvm;

        public SalaRankingPage()
        {
            srvm = new SalaRankingViewModel();
            InitializeComponent();
            BindingContext = srvm;
        }

    }
}