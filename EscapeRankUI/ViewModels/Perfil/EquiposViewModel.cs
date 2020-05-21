using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class EquiposViewModel : BaseViewModel
    {
        //Variables

        private bool _modoEliminar;
        private ObservableCollection<Equipo> _equipos;

        //Constructor

        public EquiposViewModel()
        {
            VerEquipoCommand = new Command<Equipo>(VerEquipo);
            ModoAnyadirCommand = new Command(async()=> await ActivarModoAnyadir());
            ModoEliminarCommand = new Command(ActivarModoEliminar);
            EliminarEquipoCommand = new Command<Equipo>(DeleteEquipo);

            MessagingCenter.Subscribe<EquipoNuevoViewModel>(this, "RefrescarEquipos", async (sender) =>
            {
                await GetEquipos();
            });
        }


        //Getters & Setters

        public Command VerEquipoCommand { get; }
        public Command ModoAnyadirCommand { get; }
        public Command ModoEliminarCommand { get; }
        public Command EliminarEquipoCommand { get; }

        public ObservableCollection<Equipo> Equipos
        {
            get { return _equipos; }
            set { SetProperty(ref _equipos, value); }
        }

        public bool ModoEliminar
        {
            get { return _modoEliminar; }
            set { SetProperty(ref _modoEliminar, value); }
        }

        //Funciones

        public async Task GetEquipos()
        {
            Cargando = true;

            try
            {
                List<Equipo> equiposCall = await App.PerfilService.GetEquiposAsync(); //Servicios.ServicioFake.Usuarios[0].Equipos; 
                Equipos = new ObservableCollection<Equipo>(equiposCall);
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

        private async void VerEquipo(Equipo equipoSeleccionado)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EquipoDetallePage(equipoSeleccionado));
        }

        private async void DeleteEquipo(Equipo equipo)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Borrar equipo", "¿Seguro que desea borrar equipo \"" + equipo.Nombre + "\"?", "Si", "No");

            if (respuesta)
            {
                Cargando = true;

                try
                {
                    bool borrado = await App.PerfilService.DeleteEquipoAsync(equipo.Id);
                    if (borrado)
                    {
                        await Application.Current.MainPage.DisplayAlert("Equipo \"" + equipo.Nombre + "\" eliminado con éxito", null, "Ok");
                        await GetEquipos();
                    }
                }
                catch (HttpUnauthorizedException)
                {
                    ErrorCredenciales();
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("No se ha podido eliminar el equipo \"" + equipo.Nombre + "\"", null, "Ok");
                }
                finally
                {
                    ModoEliminar = false;
                    Cargando = false;
                }
            }
        }

        private void ActivarModoEliminar()
        {
            if (!ModoEliminar)
            {
                ModoEliminar = true;
            }
            else
            {
                ModoEliminar = false;
            }
        }

        private async Task ActivarModoAnyadir()
        {
            await PopupNavigation.Instance.PushAsync(new EquipoNuevoPage());
        }


    }
}
