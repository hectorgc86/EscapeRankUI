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
        private ObservableCollection<Sala> _salasFiltradas;
        private ObservableCollection<Publico> _publico;
        private ObservableCollection<Categoria> _categorias;
        private ObservableCollection<Dificultad> _dificultades;

        //Constructor

        public SalasViewModel()
        {
            offset = 0;
            SalaSeleccionada = new Sala();
            VerSalaCommand = new Command(VerSala);

            GetSalas();
            GetCategorias();
            GetPublico();
            GetDificultades();

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


        public ObservableCollection<Publico> Publico
        {
            get { return _publico; }
            set { SetProperty(ref _publico, value); }
        }

        public ObservableCollection<Dificultad> Dificultades
        {
            get { return _dificultades; }
            set { SetProperty(ref _dificultades, value); }
        }

        public ObservableCollection<Categoria> Categorias
        {
            get { return _categorias; }
            set { SetProperty(ref _categorias, value); }
        }

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

        public ObservableCollection<Sala> SalasFiltradas
        {
            get { return _salasFiltradas; }
            set { SetProperty(ref _salasFiltradas, value); }
        }


        //Funciones

        private async void VerSala()
        {
            TabbedPage tp = new TabbedPage();

            SalaDetallePage detalle = new SalaDetallePage(_salaSeleccionada);
            SalaRankingPage ranking = new SalaRankingPage();

            detalle.Title = "Info";
            ranking.Title = "Ranking";

            tp.Title = _salaSeleccionada.Nombre;
            tp.Children.Add(detalle);
            tp.Children.Add(ranking);

           

            await Application.Current.MainPage.Navigation.PushAsync(tp);
        }

        public async Task GetCategorias()
        {
            List<Categoria> categoriasCall = Servicios.ServicioFake.Categorias;
            Categorias = new ObservableCollection<Categoria>(categoriasCall);
        }

        public async Task GetPublico()
        {
            List<Publico> publicoCall = Servicios.ServicioFake.Publico;
            Publico = new ObservableCollection<Publico>(publicoCall);
        }


        public async Task GetDificultades()
        {
            List<Dificultad> dificultadesCall = Servicios.ServicioFake.Dificultades;
            Dificultades = new ObservableCollection<Dificultad>(dificultadesCall);
        }

        public ObservableCollection<Sala> GetEscapes()
        {
            return Salas;
        }


        public ObservableCollection<Sala> Buscar(string valor)
        {

            return new ObservableCollection<Sala>(SalasFiltradas.Where(
            i => i.Nombre.ToLower().Contains(valor.ToLower()) ||
                i.Provincia.Nombre.ToLower().Contains(valor.ToLower()) ||
                i.Companyia.Nombre.ToLower().Contains(valor.ToLower()) ||
               i.Ciudad.Nombre.ToLower().Contains(valor.ToLower()) ||
                i.Tematicas.Any(t => t.Tipo.ToLower() == valor.ToLower()) ||
                i.Categorias.Any(t => t.Tipo.ToLower() == valor.ToLower()) ||
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
            SalasFiltradas = new ObservableCollection<Sala>(SalasFiltradas.Where(e => e.Categorias.Any(t => t.Tipo == valor)));
        }

        public void BuscarPorPublico(string valor)
        {
            SalasFiltradas = new ObservableCollection<Sala>(SalasFiltradas.Where(e => e.Publico.Any(t => t.Tipo == valor)));
        }

        public void ResetFiltro()
        {
            SalasFiltradas = Salas;
        }

        public async Task GetSalas()
        {
            try
            {
                List<Sala> salasCall = await App.SalasManager.GetEscapesAsync(offset); //Servicios.ServicioFake.Salas;
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

         private async Task AddLoadEscapes()
         {
             try
             {
                 List<Sala> salasCall = await App.SalasManager.GetEscapesAsync(offset); //Servicios.ServicioFake.Salas;

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
    }
}