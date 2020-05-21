using System;
using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views
{
    public partial class AmigoDetallePage : ContentPage
    {
        public AmigoDetalleViewModel advm;

        public AmigoDetallePage(Amigo amigoSeleccionado)
        {
            advm = new AmigoDetalleViewModel(amigoSeleccionado);
            InitializeComponent();
            BindingContext = advm;
        }
    }
}