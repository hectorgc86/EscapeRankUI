using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class MuroPage : ContentPage
    {
        public MuroViewModel mvm;

        public MuroPage()
        {
            mvm = new MuroViewModel();
            InitializeComponent();
            BindingContext = mvm;
        }

        protected override void OnAppearing()
        {
            mvm.GetNoticias();
        }
    }
}