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
        private Categoria _categoriaSeleccionada;
        private Tematica _tematicaSeleccionada;
        private Dificultad _dificultadSeleccionada;
        private Publico _publicoSeleccionado;
        private ObservableCollection<Sala> _salas;
        private ObservableCollection<Sala> _salasPromocionadas;
        private ObservableCollection<Sala> _salasFiltradas;
        private ObservableCollection<Categoria> _categorias;
        private ObservableCollection<Publico> _publico;
        private ObservableCollection<Dificultad> _dificultades;
        private ObservableCollection<Tematica> _tematicas;

        private ObservableCollection<Provincia> _provincias;

        //Constructor

        public SalasViewModel()
        {
            offset = 0;
            SalaSeleccionada = new Sala();
            VerSalaCommand = new Command(VerSala);

            GetSalasPromocionadas();
            GetCategorias();
            GetTematicas();
            GetPublico();
            GetDificultades();
            GetProvincias();


            /*
            MessagingCenter.Subscribe<FilteListViewModel, string>(this, "BuscarPorProvincia", (sender, arg) =>
            {
                BuscarPorProvincia(arg);
            });
            MessagingCenter.Subscribe<FilteListViewModel, string>(this, "BuscarPorTematica", (sender, arg) =>
            {
                BuscarPorTematica(arg);
            });
            MessagingCenter.Subscribe<FilteListViewModel, string>(this, "BuscarPorCategoria", (sender, arg) =>
            {
                BuscarPorCategorias(arg);
            });
            MessagingCenter.Subscribe<FilteListViewModel, string>(this, "BuscarPorPublico", (sender, arg) =>
            {
                BuscarPoPublico(arg);
            });
            MessagingCenter.Subscribe<FilteListViewModel>(this, "ResetFiltro", (sender) =>
            {
                ResetFiltro();
            });
            */
        }

        //Getters & Setters

        public ICommand VerSalaCommand { get; set; }

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

        public Categoria CategoriaSeleccionada
        {
            get { return _categoriaSeleccionada; }
            set { SetProperty(ref _categoriaSeleccionada, value); }
        }

        public ObservableCollection<Categoria> Categorias
        {
            get { return _categorias; }
            set { SetProperty(ref _categorias, value); }
        }

        public Publico PublicoSeleccionado
        {
            get { return _publicoSeleccionado; }
            set { SetProperty(ref _publicoSeleccionado, value); }
        }

        public ObservableCollection<Publico> Publico
        {
            get { return _publico; }
            set { SetProperty(ref _publico, value); }
        }

        public Tematica TematicaSeleccionada
        {
            get { return _tematicaSeleccionada; }
            set { SetProperty(ref _tematicaSeleccionada, value); }
        }

        public ObservableCollection<Tematica> Tematicas
        {
            get { return _tematicas; }
            set { SetProperty(ref _tematicas, value); }
        }

        public Dificultad DificultadSeleccionada { get; set; }

        public ObservableCollection<Dificultad> Dificultades
        {
            get { return _dificultades; }
            set { SetProperty(ref _dificultades, value); }
        }

        public Provincia ProvinciaSeleccionada { get; set; }

        public ObservableCollection<Provincia> Provincias
        {
            get { return _provincias; }
            set { SetProperty(ref _provincias, value); }
        }


        //Funciones

        private async void GetSalas()
        {
            try
            {
                List<Sala> salasCall = await App.SalasManager.GetSalasAsync(offset); //Servicios.ServicioFake.Salas;

                Salas = new ObservableCollection<Sala>(salasCall);
                SalasFiltradas = new ObservableCollection<Sala>(salasCall);
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


        public ObservableCollection<Sala> Buscar(string valor)
        {

            return new ObservableCollection<Sala>(SalasFiltradas.Where(
            i => i.Nombre.ToLower().Contains(valor.ToLower()) ||
                i.Provincia.Nombre.ToLower().Contains(valor.ToLower()) ||
                i.Companyia.Nombre.ToLower().Contains(valor.ToLower()) ||
               i.Ciudad.Nombre.ToLower().Contains(valor.ToLower()) ||
                i.Tematicas.Any(t => t.Tipo.ToLower() == valor.ToLower()) ||
            //    i.Categorias.Any(t => t.Tipo.ToLower() == valor.ToLower()) ||
                i.Publico.Any(t => t.Tipo.ToLower() == valor.ToLower())
            ));

        }
        public void BuscarPorProvincia(string valor)
        {
            SalasFiltradas = new ObservableCollection<Sala>(SalasFiltradas.Where(i => i.Provincia.Nombre == valor));
        }

        public void BuscarPorTematica(string valor)
        {
            SalasFiltradas = new ObservableCollection<Sala>(SalasFiltradas.Where(e => e.Tematicas.Any(t => t.Tipo == valor)));
        }

        public void BuscarPorCategoria(string valor)
        {
            //SalasFiltradas = new ObservableCollection<Sala>(SalasFiltradas.Where(e => e.Categorias.Any(t => t.Tipo == valor)));
        }

        public void BuscarPorPublico(string valor)
        {
            SalasFiltradas = new ObservableCollection<Sala>(SalasFiltradas.Where(e => e.Publico.Any(t => t.Tipo == valor)));
        }

        public void ResetFiltro()
        {
            SalasFiltradas = Salas;
        }

        public async void GetCategorias()
        {
            List<Categoria> categoriasCall = await App.SalasManager.GetCategoriasAsync();
            //Servicios.ServicioFake.Categorias;
            Categorias = new ObservableCollection<Categoria>(categoriasCall);
        }

        public async void GetTematicas()
        {
            List<Tematica> tematicasCall = await App.SalasManager.GetTematicasAsync();//Servicios.ServicioFake.Tematicas;
            Tematicas = new ObservableCollection<Tematica>(tematicasCall);
        }

        public async void GetPublico()
        {
            List<Publico> publicoCall = await App.SalasManager.GetPublicoAsync();//Servicios.ServicioFake.Publico;
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