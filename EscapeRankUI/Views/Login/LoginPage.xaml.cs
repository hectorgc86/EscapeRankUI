﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.ViewModels;
using Xamarin.Forms;

namespace EscapeRankUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel lvm;

        public LoginPage()
        {
            lvm = new LoginViewModel(Navigation);
            InitializeComponent();
            BindingContext = lvm;
        }
    }
}
