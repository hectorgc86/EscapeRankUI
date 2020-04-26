using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
//using MvvmAspire;
using EscapeRankUI.Modelos;
using System.Windows.Input;
using System.Diagnostics;
using EscapeRankUI.Views;


namespace EscapeRankUI.ViewModels
{
    public class SalasViewModel : BaseViewModel
    {
        //Variables

        private int offset;
        private Sala _salaSeleccionada;

        private ObservableCollection<Sala> _salas;
        private ObservableCollection<Sala> _salasPromocionadas;
        private ObservableCollection<Sala> _salasFiltradas;
        private ObservableCollection<Categoria> _categorias;
        private ObservableCollection<Publico> _publico;
        private ObservableCollection<Dificultad> _dificultades;
        private ObservableCollection<Tematica> _tematicas;
        private ObservableCollection<Provincia> _provincias;

        public object ObjetoSeleccionado { get; set; }
        public Categoria CategoriaSeleccionada { get; set; }
        public Tematica TematicaSeleccionada { get; set; }
        public Publico PublicoSeleccionado { get; set; }
        public Dificultad DificultadSeleccionada { get; set; }
        public Provincia ProvinciaSeleccionada { get; set; }

        //Constructor

        public SalasViewModel()
        {
            offset = 0;
            SalaSeleccionada = new Sala();
            VerSalaCommand = new Command(VerSala);
            VerFiltradasCommand = new Command(VerFiltradas);
            VerTodasCommand = new Command(VerTodas);

            GetSalasPromocionadas();
            GetCategorias();
            GetTematicas();
            GetPublico();
            GetDificultades();
            GetProvincias();
        }

        
        //Getters & Setters

        public Command VerSalaCommand { get; }
        public Command VerFiltradasCommand { get; }
        public Command VerTodasCommand { get; }

        public Sala SalaSeleccionada
        {
            get { return _salaSeleccionada; }
            set { SetProperty(ref _salaSeleccionada, value); }
        }

        public ObservableCollection<Sala> Salas
        {
            get { return _salas; }
            set { SetProperty(ref _salas, value); }
        }

        public ObservableCollection<Sala> SalasPromocionadas
        {
            get { return _salasPromocionadas; }
            set { SetProperty(ref _salasPromocionadas, value); }
        }

        public ObservableCollection<Sala> SalasFiltradas
        {
            get { return _salasFiltradas; }
            set { SetProperty(ref _salasFiltradas, value); }
        }

        public ObservableCollection<Categoria> Categorias
        {
            get { return _categorias; }
            set { SetProperty(ref _categorias, value); }
        }

        public ObservableCollection<Publico> Publico
        {
            get { return _publico; }
            set { SetProperty(ref _publico, value); }
        }

        public ObservableCollection<Tematica> Tematicas
        {
            get { return _tematicas; }
            set { SetProperty(ref _tematicas, value); }
        }

        public ObservableCollection<Dificultad> Dificultades
        {
            get { return _dificultades; }
            set { SetProperty(ref _dificultades, value); }
        }


        public ObservableCollection<Provincia> Provincias
        {
            get { return _provincias; }
            set { SetProperty(ref _provincias, value); }
        }


        //Funciones


        public async void GetSalasPromocionadas()
        {
            try
            {

                List<Sala> salasPromocionadasCall = await App.SalasManager.GetSalasPromocionadasAsync(offset); //Servicios.ServicioFake.Salas;
                SalasPromocionadas = new ObservableCollection<Sala>(salasPromocionadasCall);
                offset += 10;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "An error occurred",
                    e.Message,
                    "Ok"
                );
            }

        }

        private async void VerSala()
        {
            TabbedPage tp = new TabbedPage();

            SalaDetallePage detalle = new SalaDetallePage(_salaSeleccionada);
            SalaRankingPage ranking = new SalaRankingPage(_salaSeleccionada);

            detalle.Title = "Info";
            ranking.Title = "Ranking";

            tp.Title = _salaSeleccionada.Nombre;
            tp.Children.Add(detalle);
            tp.Children.Add(ranking);

            await Application.Current.MainPage.Navigation.PushAsync(tp);
        }

        private async void VerFiltradas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SalasFiltradasPage(ObjetoSeleccionado));
        }

        private async void VerTodas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SalasFiltradasPage(null));
        }

        public async void GetCategorias()
        {
            List<Categoria> categoriasCall = await App.SalasManager.GetCategoriasAsync();
            //Servicios.ServicioFake.Categorias;
            Categorias = new ObservableCollection<Categoria>(categoriasCall);
        }

        public async void GetTematicas()
        {
            List<Tematica> tematicasCall = await App.SalasManager.GetTematicasAsync();
            //Servicios.ServicioFake.Tematicas;
            Tematicas = new ObservableCollection<Tematica>(tematicasCall);
        }

        public async void GetPublico()
        {
            List<Publico> publicoCall = await App.SalasManager.GetPublicoAsync();
            //Servicios.ServicioFake.Publico;
            Publico = new ObservableCollection<Publico>(publicoCall);
        }


        public async void GetDificultades()
        {
            List<Dificultad> dificultadesCall = await App.SalasManager.GetDificultadesAsync();//Servicios.ServicioFake.Dificultades;
            Dificultades = new ObservableCollection<Dificultad>(dificultadesCall);
        }

        public async void GetProvincias()
        {
            List<Provincia> provinciasCall = await App.SalasManager.GetProvinciasAsync();//Servicios.ServicioFake.Provincias;
            Provincias = new ObservableCollection<Provincia>(provinciasCall);

        }


    }
}