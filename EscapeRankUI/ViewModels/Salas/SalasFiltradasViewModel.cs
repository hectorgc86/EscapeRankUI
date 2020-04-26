using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using EscapeRankUI.Modelos;
using System.Diagnostics;
using EscapeRankUI.Views;


namespace EscapeRankUI.ViewModels
{
    public class SalasFiltradasViewModel : BaseViewModel
    {
        private int _umbral;
        private object _filtro;
        private string _titulo;
        private string _busqueda;
        private Sala _salaSeleccionada;

        public Command VerSalaCommand { get; }
        public Command BuscarSalasCommand { get; }
        public Command CargarSalasCommand { get; }

        public ObservableCollection<Sala> Salas { get; set; }

        //Constructor

        public SalasFiltradasViewModel(object filtro)
        {
            _filtro = filtro;

            Umbral = 1;

            Salas = new ObservableCollection<Sala>();

            if (filtro != null)
            {
                Titulo = filtro.GetType().Name + " " + filtro.GetType().GetProperty("Tipo").GetValue(filtro, null).ToString().ToLower();
            }
            else
            {
                Titulo = "Todas las salas";
            }

            VerSalaCommand = new Command(VerSala);
            BuscarSalasCommand = new Command(CargarSalasFiltradas);
            CargarSalasCommand = new Command(async () => await CargarSalas());

            _ = CargarSalas();
        }

        public Sala SalaSeleccionada
        {
            get { return _salaSeleccionada; }
            set { SetProperty(ref _salaSeleccionada, value); }
        }

        public string Busqueda
        {
            get { return _busqueda; }
            set { SetProperty(ref _busqueda, value);

                if(_busqueda.Count() == 0)
                {
                    CargarSalasFiltradas();
                }
            }
        }

        public int Umbral
        {
            get { return _umbral; }
            set { SetProperty(ref _umbral, value); }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        //Funciones



        private async void VerSala()
        {
            TabbedPage tp = new TabbedPage();

            SalaDetallePage detalle = new SalaDetallePage(SalaSeleccionada);
            SalaRankingPage ranking = new SalaRankingPage(SalaSeleccionada);

            detalle.Title = "Info";
            ranking.Title = "Ranking";

            tp.Title = SalaSeleccionada.Nombre;
            tp.Children.Add(detalle);
            tp.Children.Add(ranking);

            await Application.Current.MainPage.Navigation.PushAsync(tp);
        }

        private async Task CargarSalas()
        {
            if (Cargando)
                return;

            Cargando = true;

            try
            {
                List<Sala> salasCall;

                if (_filtro is Categoria categoriaFiltro)
                {
                    salasCall = await App.SalasManager.GetSalasCategoriaAsync(categoriaFiltro.Id, Salas.Count, Busqueda);
                }
                else if (_filtro is Tematica tematicaFiltro)
                {
                    salasCall = await App.SalasManager.GetSalasTematicaAsync(tematicaFiltro.Id, Salas.Count, Busqueda);
                }
                else if (_filtro is Publico publicoFiltro)
                {
                    salasCall = await App.SalasManager.GetSalasPublicoAsync(publicoFiltro.Id, Salas.Count, Busqueda);
                }
                else if (_filtro is Dificultad dificultadFiltro)
                {
                    salasCall = await App.SalasManager.GetSalasDificultadAsync(dificultadFiltro.Id, Salas.Count, Busqueda);
                }
                else
                {
                    salasCall = await App.SalasManager.GetSalasAsync(Salas.Count, Busqueda);
                }

                foreach (Sala sala in salasCall)
                {
                    Salas.Add(sala);
                }

                if (salasCall.Count() == 0)
                {
                    Umbral = -1;
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Cargando = false;
            }
        }
        private void CargarSalasFiltradas()
        {
             Umbral = 1;
             Salas.Clear();
             _ = CargarSalas();
        }
    }
}