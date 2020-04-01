using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
//using MvvmAspire;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.ViewModels.Salas
{
    public class SalasViewModel : BaseViewModel
    {
        private int offset;

        public SalasViewModel(INavigation navigation)
        {
            offset = 0;

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

        public async Task GetCategorias()
        {
         //   if (Cargando)
           //     return;

 //           Cargando = true;

            List<Categoria> categoriasCall = Servicios.ServicioFake.Categorias;

            Categorias = new ObservableCollection<Categoria>(categoriasCall);

        }

        public async Task GetPublico()
        {
           // if (Cargando)
             //   return;

          //  Cargando = true;

            List<Publico> publicoCall = Servicios.ServicioFake.Publico;

            Publico = new ObservableCollection<Publico>(publicoCall);

        }


        public async Task GetDificultades()
        {
         //   if (Cargando)
           //     return;

        //    Cargando = true;

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
            if (Cargando)
                return;
            try
            {
                Cargando = true;
                List<Sala> salasCall = Servicios.ServicioFake.Salas; //await App.EscapeManager.GetEscapesAsync(offset);
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

        /* private async Task AddLoadEscapes()
         {
             if (Cargando)
                 return;
             try
             {

                 Cargando = true;

                 List<Sala> salasCall = Servicios.ServicioFake.Salas; //await App.EscapeManager.GetEscapesAsync(offset);

                 List<Sala> newEscapes = new ObservableCollection<Sala>(salasCall);
                 Salas.AddRange(newEscapes);
                 SalasFiltradas.AddRange(newEscapes);
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

         }*/
    }
}