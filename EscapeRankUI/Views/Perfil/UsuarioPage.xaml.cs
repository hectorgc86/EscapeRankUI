using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Perfil;
using System;

namespace EscapeRankUI.Views.Perfil
{
    public partial class UsuarioPage : ContentPage
    {
        public UsuarioViewModel uvm;

        public UsuarioPage()
        {
            uvm = new UsuarioViewModel();
            InitializeComponent();
            BindingContext = uvm;

            if (uvm.Usuario.Nacido.HasValue)
            {
                Edad.Text = (DateTime.Now.Year - uvm.Usuario.Nacido.Value.Year).ToString();
            }
        }
    }
}