using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class AmigosViewModel : BaseViewModel
    {
        //Variables

        private bool _modoEliminar;
        private ObservableCollection<Amigo> _amigos;
        private ObservableCollection<Amigo> _amigosPendientes;


        //Constructor

        public AmigosViewModel()
        {
            VerAmigoCommand = new Command<Amigo>(VerAmigo);
            ModoAnyadirCommand = new Command(ActivarModoAnyadir);
            ModoEliminarCommand = new Command(ActivarModoEliminar);
            AceptarAmigoCommand = new Command<Amigo>(AceptarAmigo);
            EliminarAmigoCommand = new Command<Amigo>(DeleteAmigo);
        }

        
        //Getters & Setters

        public Command VerAmigoCommand { get; }
        public Command ModoAnyadirCommand { get; }
        public Command ModoEliminarCommand { get; }
        public Command AceptarAmigoCommand { get; }
        public Command EliminarAmigoCommand { get; }

        public bool ModoEliminar
        {
            get { return _modoEliminar; }
            set { SetProperty(ref _modoEliminar, value); }
        }

        public ObservableCollection<Amigo> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        public ObservableCollection<Amigo> AmigosPendientes
        {
            get { return _amigosPendientes; }
            set { SetProperty(ref _amigosPendientes, value); }
        }

        //Funciones

        public async void GetAmigos()
        {
            Cargando = true;

            try
            {
                List<Amigo> amigosCall = await App.PerfilService.GetAmigosAsync(); //Servicios.ServicioFake.Usuarios[0].Amigos; 
                Amigos = new ObservableCollection<Amigo>(amigosCall.Where(a=>a.Estado == Estado.aceptado));
                AmigosPendientes = new ObservableCollection<Amigo>(amigosCall.Where(a => a.Estado == Estado.pendiente));
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


        private async void VerAmigo(Amigo amigoSeleccionado)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AmigoDetallePage(amigoSeleccionado));
        }

        private async void AceptarAmigo(Amigo amigo)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Aceptar amigo", amigo.Perfil.Nombre + " te ha enviado una solicitud de amistad \n ¿Deseas aceptarla?", "Si", "No");

            if (respuesta)
            {
                Cargando = true;

                try
                {
                    bool aceptado = await App.PerfilService.PutAmigoAsync(amigo);
                    if (aceptado)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ahora eres amigo de " + amigo.Perfil.Nombre, null, "Ok");
                        GetAmigos();
                    }
                }
                catch (HttpUnauthorizedException)
                {
                    ErrorCredenciales();
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("No se ha podido aceptar a \"" + amigo.Perfil.Nombre + "\"", null, "Ok");
                }
                finally
                {
                    Cargando = false;
                }
            }
        }

        private async void DeleteAmigo(Amigo amigo)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Borrar amigo", "¿Seguro que desea borrar a \"" + amigo.Perfil.Nombre + "\"?", "Si", "No");

            if (respuesta)
            {
                Cargando = true;

                try
                {
                    bool borrado = await App.PerfilService.DeleteAmigoAsync(amigo.Id);
                    if (borrado)
                    {
                        await Application.Current.MainPage.DisplayAlert(amigo.Perfil.Nombre + "\" se ha borrado de tu lista de amigos", null, "Ok");
                        GetAmigos();
                    }
                }
                catch (HttpUnauthorizedException)
                {
                    ErrorCredenciales();
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("No se ha podido borrar a \"" + amigo.Perfil.Nombre + "\"", null, "Ok");
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

        private void ActivarModoAnyadir()
        {
            PopupNavigation.Instance.PushAsync(new AmigoNuevoPage());
        }
    }
}
