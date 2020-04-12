using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Partida;
using Xamarin.Forms;

namespace EscapeRankUI.Views.Partida
{
    public partial class PartidaPage : ContentPage
    {
        public PartidaViewModel pvm;

        public PartidaPage()
        {
            pvm = new PartidaViewModel();
            InitializeComponent();
            BindingContext = pvm;
        }
    }
}