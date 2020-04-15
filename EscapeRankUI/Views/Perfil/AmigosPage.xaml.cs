using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class AmigosPage : ContentPage
    {
        public AmigosViewModel avm;

        public AmigosPage()
        {
            avm = new AmigosViewModel();
            InitializeComponent();
            BindingContext = avm;
        }
    }
}