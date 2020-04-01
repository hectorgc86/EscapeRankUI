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
            avm = new AmigosViewModel(Navigation);
            InitializeComponent();
            BindingContext = avm;
        }

        private void ActivarSwitchTema(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                Application.Current.Resources.Clear();
                Application.Current.Resources = new Oscuro();
            }
            else
            {
                Application.Current.Resources.Clear();
                Application.Current.Resources = new Claro();
            }
        }
    }
}