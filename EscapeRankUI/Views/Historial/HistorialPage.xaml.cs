using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Estilos.Temas;

namespace EscapeRankUI.Views.Historial
{
    public partial class HistorialPage : ContentPage
    {
        public HistorialPage()
        {
            InitializeComponent();
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