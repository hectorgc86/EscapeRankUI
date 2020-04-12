using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Muro;
using System.Diagnostics;

namespace EscapeRankUI.Views.Muro
{
    public partial class MuroPage : ContentPage
    {
        public MuroViewModel mvm;

        public MuroPage()
        {
            mvm = new MuroViewModel();
            InitializeComponent();
            BindingContext = mvm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }

}