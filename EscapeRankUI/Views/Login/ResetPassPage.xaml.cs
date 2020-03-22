using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.ViewModels;
using Xamarin.Forms;

namespace EscapeRankUI.Views
{
    public partial class ResetPassPage : ContentPage
    {
        public ResetPassViewModel rpvm;

        public ResetPassPage()
        {
            rpvm = new ResetPassViewModel(Navigation);
            InitializeComponent();
            BindingContext = rpvm;
        }
    }
}
