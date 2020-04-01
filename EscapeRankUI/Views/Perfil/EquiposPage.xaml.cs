using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Perfil;

namespace EscapeRankUI.Views.Perfil
{
    public partial class EquiposPage : ContentPage
    {
        public EquiposViewModel evm;

        public EquiposPage()
        {
            evm = new EquiposViewModel(Navigation);
            InitializeComponent();
            BindingContext = evm;
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