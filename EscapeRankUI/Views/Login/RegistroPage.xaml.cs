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
    public partial class RegistroPage : ContentPage
    {
        public RegistroViewModel rvm;

        public RegistroPage()
        {
            rvm = new RegistroViewModel(Navigation);
            InitializeComponent();
            BindingContext = rvm;


        }
    }
}
