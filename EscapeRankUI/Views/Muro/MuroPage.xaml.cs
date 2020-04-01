using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Muro;

namespace EscapeRankUI.Views.Muro
{
    public partial class MuroPage : ContentPage
    {
        public MuroViewModel mvm;

        public MuroPage()
        {
            InitializeComponent();

            mvm = new MuroViewModel(Navigation);
            InitializeComponent();
            BindingContext = mvm;
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