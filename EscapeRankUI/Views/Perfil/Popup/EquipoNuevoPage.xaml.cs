using System;
using System.Collections.Generic;
using EscapeRankUI.ViewModels;
using Xamarin.Forms;

namespace EscapeRankUI.Views
{
    public partial class EquipoNuevoPage
    {
        public EquipoNuevoViewModel envm;

        public EquipoNuevoPage()
        {
            envm = new EquipoNuevoViewModel();
            InitializeComponent();
            BindingContext = envm;
        }
    }
}
