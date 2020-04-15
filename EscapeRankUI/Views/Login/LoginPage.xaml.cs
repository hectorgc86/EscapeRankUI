using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel lvm;

        public LoginPage()
        {
            lvm = new LoginViewModel();
            InitializeComponent();
            BindingContext = lvm;
        }
    }
}
