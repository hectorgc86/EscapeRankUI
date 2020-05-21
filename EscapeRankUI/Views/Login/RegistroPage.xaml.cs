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

        void Entry_Focused(object sender, FocusEventArgs e)
        {
            EntryNacimiento.Placeholder = "Fecha nacimiento (dd/mm/yyyy)";
        }

        void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            EntryNacimiento.Placeholder = "Fecha nacimiento";
        }
    }
}
