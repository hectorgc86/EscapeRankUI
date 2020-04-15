using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroViewModel rvm;

        public RegistroPage()
        {
            rvm = new RegistroViewModel();
            InitializeComponent();
            BindingContext = rvm;


        }
    }
}
