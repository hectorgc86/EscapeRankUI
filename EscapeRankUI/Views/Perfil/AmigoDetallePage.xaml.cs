using System;
using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views
{
    public partial class AmigoDetallePage : ContentPage
    {
        public AmigoDetalleViewModel advm;

        public AmigoDetallePage(Usuario amigoSeleccionado)
        {
            advm = new AmigoDetalleViewModel(amigoSeleccionado);
            InitializeComponent();
            BindingContext = advm;

            if (advm.Amigo.Nacido.HasValue)
            {
                Edad.Text = (DateTime.Now.Year - advm.Amigo.Nacido.Value.Year).ToString();
            }
        }
    }
}