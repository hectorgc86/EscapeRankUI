using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Perfil;
using System;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views.Perfil
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