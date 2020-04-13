using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.ViewModels.Salas;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Views.Salas
{
    public partial class SalasPage : ContentPage
    {
        public SalasViewModel svm;
        private string filtroSeleccionado;
        private List<Sala> listaSalas;

        public SalasPage()
        {
            svm = new SalasViewModel();
            InitializeComponent();
            BindingContext = svm;

            ResultadoBusqueda.IsVisible = false;
            listaSalas = new List<Sala>(svm.Salas);

            filtroSeleccionado = "Todos";
            Buscador.Placeholder = "Nombre, ciudad o compañia..";
        }

        private void Buscador_TextChanged(object sender, TextChangedEventArgs e) {

            string letras = Buscador.Text;

            List<Sala> salasFiltradas = new List<Sala>();

            switch (filtroSeleccionado)
            {
                case "Nombre":
                    salasFiltradas = listaSalas.Where(s => s.Nombre.ToLower().Contains(letras.ToLower())).ToList();
                    break;
                case "Ciudad":
                    salasFiltradas = listaSalas.Where(s => s.Ciudad.Nombre.ToLower().Contains(letras.ToLower())).ToList();
                    break;
                case "Compañia":
                    salasFiltradas = listaSalas.Where(s => s.Companyia.Nombre.ToLower().Contains(letras.ToLower())).ToList();
                    break;
                case "Todos":
                    salasFiltradas = listaSalas.Where(s => s.Nombre.ToLower().Contains(letras.ToLower()) || s.Ciudad.Nombre.ToLower().Contains(letras.ToLower()) || s.Companyia.Nombre.ToLower().Contains(letras.ToLower())).ToList();
                    break;
            }

            ResultadoBusqueda.ItemsSource = salasFiltradas;

            ResultadoBusqueda.IsVisible = e.NewTextValue.Length > 0;

        }

        async void ImageButton_ClickedAsync(object sender, EventArgs e)
        {
            filtroSeleccionado = await DisplayActionSheet("Seleccione filtro de búsqueda:", null, null, "Nombre", "Ciudad", "Compañia", "Todos");

            switch (filtroSeleccionado)
            {
                case "Nombre":
                    Buscador.Placeholder = "Introduzca nombre de sala..";
                    break;
                case "Ciudad":
                    Buscador.Placeholder = "Introduzca ciudad..";
                    break;
                case "Compañia":
                    Buscador.Placeholder = "Introduzca compañia..";
                    break;
                case "Todos":
                    Buscador.Placeholder = "Nombre, ciudad o compañia..";
                    break;
            }
        }

    }
}