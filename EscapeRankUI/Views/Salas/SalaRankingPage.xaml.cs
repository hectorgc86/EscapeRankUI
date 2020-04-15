using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
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