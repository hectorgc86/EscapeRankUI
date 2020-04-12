using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.ViewModels.Login;
using Xamarin.Forms;

namespace EscapeRankUI.Views.Login
{
    public partial class ResetPassPage : ContentPage
    {
        public ResetPassViewModel rpvm;

        public ResetPassPage()
        {
            rpvm = new ResetPassViewModel();
            InitializeComponent();
            BindingContext = rpvm;
        }
    }
}
