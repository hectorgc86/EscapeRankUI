using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using EscapeRankUI.ViewModels.Historial;

namespace EscapeRankUI.Views.Historial
{
    public partial class HistorialPage : ContentPage
    {
        public HistorialViewModel hvm;

        public HistorialPage()
        {
            hvm = new HistorialViewModel();
            InitializeComponent();
            BindingContext = hvm;
        }
    }
}