using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.Estilos.Temas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EscapeRankUI.Views.Partida
{
    public partial class PartidaPage : ContentPage
    {
        public PartidaPage()
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