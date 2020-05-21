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

        protected override void OnAppearing()
        {
                pvm.GetEquipos();
        }

        protected void Picker_SelectedIndexChanged(object obj , EventArgs a)
        {
            Picker picker = obj as Picker;

            if(picker.SelectedIndex != -1)
            {
                pvm.NumeroEquipoSeleccionado = picker.SelectedIndex;
            }
        }
    }
}