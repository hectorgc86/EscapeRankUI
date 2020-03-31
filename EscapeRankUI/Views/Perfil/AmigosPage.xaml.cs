﻿using Xamarin.Forms;
using EscapeRankUI.Estilos.Temas;

namespace EscapeRankUI.Views.Perfil
{
    public partial class AmigosPage : ContentPage
    {
        public AmigosPage()
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