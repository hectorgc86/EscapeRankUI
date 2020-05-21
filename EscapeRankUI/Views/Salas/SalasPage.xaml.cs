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
        private readonly SalasViewModel svm;

        public SalasPage()
        {
            svm = new SalasViewModel();
            InitializeComponent();
            BindingContext = svm;
        }

        protected override void OnAppearing()
        {
            svm.GetSalasPromocionadas();
        }

        void CollectionView_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
    }
}