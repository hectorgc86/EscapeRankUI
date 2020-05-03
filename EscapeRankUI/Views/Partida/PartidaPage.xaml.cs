using Xamarin.Forms;
using EscapeRankUI.ViewModels;
using System;

namespace EscapeRankUI.Views
{
    public partial class PartidaPage : ContentPage
    {
        public PartidaViewModel pvm;

        public PartidaPage()
        {
            pvm = new PartidaViewModel();
            InitializeComponent();
            BindingContext = pvm;
        }
    }
}