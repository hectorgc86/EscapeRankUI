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
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel lvm;

        public LoginPage()
        {
            lvm = new LoginViewModel();
            InitializeComponent();
            BindingContext = lvm;
        }
    }
}
