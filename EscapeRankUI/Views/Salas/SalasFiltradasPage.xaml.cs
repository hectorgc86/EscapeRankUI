using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using EscapeRankUI.Modelos;
using EscapeRankUI.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace EscapeRankUI.Views
{
    public partial class SalasFiltradasPage : ContentPage
    {
        public SalasFiltradasViewModel sfvm;

        public SalasFiltradasPage(object filtro)
        {
            sfvm = new SalasFiltradasViewModel(filtro);
            InitializeComponent();
            BindingContext = sfvm;
        }
    }
}