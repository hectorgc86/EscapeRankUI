using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using EscapeRankUI.Modelos;
using EscapeRankUI.ViewModels;

namespace EscapeRankUI.Views
{
    public partial class SalasPage : ContentPage
    {
        public SalasViewModel svm;

        public SalasPage()
        {
            svm = new SalasViewModel();
            InitializeComponent();
            BindingContext = svm;
        }
    }
}