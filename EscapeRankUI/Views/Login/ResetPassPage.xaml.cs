using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class ResetPassPage : ContentPage
    {
        public ResetPassViewModel rpvm;

        public ResetPassPage()
        {
            rpvm = new ResetPassViewModel();
            InitializeComponent();
            BindingContext = rpvm;
        }
    }
}
