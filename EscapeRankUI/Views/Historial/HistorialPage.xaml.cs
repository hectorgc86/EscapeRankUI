using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class HistorialPage : ContentPage
    {
        public HistorialViewModel hvm;

        public HistorialPage()
        {
            hvm = new HistorialViewModel();
            InitializeComponent();
            BindingContext = hvm;
        }
    }
}