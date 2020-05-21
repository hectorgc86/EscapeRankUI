using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;


namespace EscapeRankUI.ViewModels
{
    public class SalasFiltradasViewModel : BaseViewModel
    {
        private int _umbral;
        private string _titulo;
        private string _busqueda;
        private readonly object _filtro;
        private ObservableCollection<Sala> _salas;

        public Command VerSalaCommand { get; }
        public Command BuscarSalasCommand { get; }
        public Command CargarSalasCommand { get; }

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

        public ObservableCollection<Sala> Salas
        {
            get { return _salas; }
            set { SetProperty(ref _salas, value); }
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
                    salasCall = await App.SalasService.GetSalasCategoriaAsync(categoriaFiltro.Id, Salas.Count, Busqueda);
                }
                else if (_filtro is Tematica tematicaFiltro)
                {
                    salasCall = await App.SalasService.GetSalasTematicaAsync(tematicaFiltro.Id, Salas.Count, Busqueda);
                }
                else if (_filtro is Publico publicoFiltro)
                {
                    salasCall = await App.SalasService.GetSalasPublicoAsync(publicoFiltro.Id, Salas.Count, Busqueda);
                }
                else if (_filtro is Dificultad dificultadFiltro)
                {
                    salasCall = await App.SalasService.GetSalasDificultadAsync(dificultadFiltro.Id, Salas.Count, Busqueda);
                }
                else
                {
                    salasCall = await App.SalasService.GetSalasAsync(Salas.Count, Busqueda);
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
            catch (HttpUnauthorizedException)
            {
               ErrorCredenciales();
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