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
            uvm = new UsuarioViewModel(Navigation);
            InitializeComponent();
            BindingContext = uvm;

            if (uvm.Usuario.Nacido.HasValue)
            {
                Edad.Text = (DateTime.Now.Year - uvm.Usuario.Nacido.Value.Year).ToString();
            }
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