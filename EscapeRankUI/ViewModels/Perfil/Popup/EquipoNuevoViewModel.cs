using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EscapeRankUI.Modelos;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class EquipoNuevoViewModel : BaseViewModel
    {
        private string _nombreEquipo;
        private ObservableCollection<Amigo> _amigosUsuario;
        private List<object> _miembrosSeleccionados;

        public EquipoNuevoViewModel()
        {
            MiembrosSeleccionados = new List<object>();

            CrearEquipoCommand = new Command(CrearEquipo);
            GetAmigos();
        }

        public Command CrearEquipoCommand { get; }

        public string NombreEquipo
        {
            get { return _nombreEquipo; }
            set { SetProperty(ref _nombreEquipo, value); }
        }

        public ObservableCollection<Amigo> AmigosUsuario
        {
            get { return _amigosUsuario; }
            set { SetProperty(ref _amigosUsuario, value); }
        }

        public List<object> MiembrosSeleccionados
        {
            get { return _miembrosSeleccionados; }
            set { SetProperty(ref _miembrosSeleccionados, value); }
        }

        public async void GetAmigos()
        {
            Cargando = true;

            try
            {
                List<Amigo> amigosCall = await App.PerfilService.GetAmigosAsync(); //Servicios.ServicioFake.Usuarios[0].Amigos; 
                AmigosUsuario = new ObservableCollection<Amigo>(amigosCall.Where(e => e.Estado == Estado.aceptado));
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

        private async void CrearEquipo()
        {
            if (string.IsNullOrEmpty(NombreEquipo))
            {
                await Application.Current.MainPage.DisplayAlert("El campo nombre no debe estar vacío", null, "Ok");
            }
            else if (MiembrosSeleccionados.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Debe seleccionar mínimo un miembro para el equipo", null, "Ok");
            }
            else
            {
                Cargando = true;

                Equipo equipo = new Equipo {
                    Nombre = NombreEquipo,
                    Usuarios = MiembrosSeleccionados.Cast<Usuario>().ToList()
                };

                equipo.Usuarios.Add(App.UsuarioPrincipal);

                try
                {
                    bool creado = await App.PerfilService.PostEquipoAsync(equipo);

                    if (creado)
                    {
                        await Application.Current.MainPage.DisplayAlert("Equipo creado con éxito", null, "Ok");
                        MessagingCenter.Send(this, "RefrescarEquipos");
                    }
                }
                catch (HttpUnauthorizedException)
                {
                    ErrorCredenciales();
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("No se ha podido crear equipo", null, "Ok");
                }
                finally
                {
                    Cargando = false;
                    await PopupNavigation.Instance.PopAsync();
                }
            }
        }
    }
}
