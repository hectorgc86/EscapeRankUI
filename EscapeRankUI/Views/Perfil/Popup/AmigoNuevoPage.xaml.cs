using System;
using System.Collections.Generic;
using EscapeRankUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EscapeRankUI.Views
{
    public partial class AmigoNuevoPage
    {
        public AmigoNuevoViewModel anvm;

        public AmigoNuevoPage()
        {
            anvm = new AmigoNuevoViewModel();
            InitializeComponent();
            BindingContext = anvm;
        }
    }
}
