using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;


namespace EscapeRankUI.ViewModels
{
    public class SalasViewModel : BaseViewModel
    {
        //Variables

        private readonly int offset;
        private ObservableCollection<Sala> _salas;
        private ObservableCollection<Sala> _salasPromocionadas;
        private ObservableCollection<Categoria> _categorias;
        private ObservableCollection<Tematica> _tematicas;
        private ObservableCollection<Publico> _publico;
        private ObservableCollection<Dificultad> _dificultades;

        public Sala SalaSeleccionada { get; set; }
        public object FiltroSeleccionado { get; set; }

        public Command VerSalaCommand { get; }
        public Command VerFiltradasCommand { get; }
        public Command VerTodasCommand { get; }

        //Constructor

        public SalasViewModel()
        {
            offset = 0;
            SalaSeleccionada = new Sala();
            VerSalaCommand = new Command(VerSala);
            VerFiltradasCommand = new Command(VerFiltradas);
            VerTodasCommand = new Command(VerTodas);

            SalasPromocionadas = new ObservableCollection<Sala>();

            GetCategorias();
            GetTematicas();
            GetPublico();
            GetDificultades();
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

        //Funciones

        public async void GetSalasPromocionadas()
        {
            Cargando = true;

            try
            {
                List<Sala> salasPromocionadasCall = await App.SalasService.GetSalasPromocionadasAsync(offset); //Servicios.ServicioFake.Salas;
                SalasPromocionadas = new ObservableCollection<Sala>(salasPromocionadasCall);
            }
            catch (HttpUnauthorizedException)
            {
                ErrorCredenciales();
            }
            finally
            {
                Cargando = false;
            }
        }

        private async void VerSala()
        {

            TabbedPage tp = new TabbedPage {
                BarBackgroundColor = (Color)Utils.GetResourceValue("azul1"),
                BarTextColor = (Color)Utils.GetResourceValue("blanco1"),
                UnselectedTabColor = (Color)Utils.GetResourceValue("gris2")
            };
        
            SalaDetallePage detalle = new SalaDetallePage(SalaSeleccionada);
            SalaRankingPage ranking = new SalaRankingPage(SalaSeleccionada);

            tp.Title = SalaSeleccionada.Nombre;
            tp.Children.Add(detalle);
            tp.Children.Add(ranking);

            await Application.Current.MainPage.Navigation.PushAsync(tp);
        }

        private async void VerFiltradas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SalasFiltradasPage(FiltroSeleccionado));
        }

        private async void VerTodas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SalasFiltradasPage(null));
        }

        private async void GetCategorias()
        {
            Cargando = true;

            try
            {
                List<Categoria> categoriasCall = await App.SalasService.GetCategoriasAsync();
                //Servicios.ServicioFake.Categorias;
                Categorias = new ObservableCollection<Categoria>(categoriasCall);
            }
            catch
            {
                ErrorCredenciales();
                Cargando = false;
            }    
        }

        private async void GetTematicas()
        {
            try
            {
                List<Tematica> tematicasCall = await App.SalasService.GetTematicasAsync();
                //Servicios.ServicioFake.Tematicas;
                Tematicas = new ObservableCollection<Tematica>(tematicasCall);
            }
            catch
            {
                ErrorCredenciales();
                Cargando = false;
            }
        }

        private async void GetPublico()
        {
            try
            {
                List<Publico> publicoCall = await App.SalasService.GetPublicoAsync();
                //Servicios.ServicioFake.Publico;
                Publico = new ObservableCollection<Publico>(publicoCall);
            }
            catch
            {
                ErrorCredenciales();
                Cargando = false;
            }

        }

        private async void GetDificultades()
        {
            try
            {
                List<Dificultad> dificultadesCall = await App.SalasService.GetDificultadesAsync();//Servicios.ServicioFake.Dificultades;
                Dificultades = new ObservableCollection<Dificultad>(dificultadesCall);
            }
            catch
            {
                ErrorCredenciales();
                Cargando = false;
            }
        }
    }
}