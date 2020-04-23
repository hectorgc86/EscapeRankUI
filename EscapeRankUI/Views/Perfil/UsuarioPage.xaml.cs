using System;
using Xamarin.Forms;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class UsuarioPage : ContentPage
    {
        public UsuarioViewModel uvm;

        public UsuarioPage()
        {
            uvm = new UsuarioViewModel();
            InitializeComponent();
            BindingContext = uvm;
        }
    }
}