using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class PartidaPage : ContentPage
    {
        public PartidaViewModel pvm;

        public PartidaPage()
        {
            pvm = new PartidaViewModel();
            InitializeComponent();
            BindingContext = pvm;
        }
    }
}