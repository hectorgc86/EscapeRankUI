using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Perfil;

namespace EscapeRankUI.Views.Perfil
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