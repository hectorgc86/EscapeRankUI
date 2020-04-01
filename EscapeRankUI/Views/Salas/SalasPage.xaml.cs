using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels;
using EscapeRankUI.ViewModels.Salas;

namespace EscapeRankUI.Views.Salas
{
    public partial class SalasPage : ContentPage
    {
        public SalasViewModel svm;

        public SalasPage()
        {
            InitializeComponent();

            svm = new SalasViewModel(Navigation);
            InitializeComponent();
            BindingContext = svm;
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