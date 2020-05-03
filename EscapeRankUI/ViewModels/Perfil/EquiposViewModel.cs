using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class EquiposViewModel : BaseViewModel
    {
        //Variables

        private ObservableCollection<Equipo> _equipos;

        //Constructor

        public EquiposViewModel()
        {
            VerEquipoCommand = new Command<Equipo>(VerEquipo);

            GetEquipos();
        }

        //Getters & Setters

        public Command VerEquipoCommand { get; }

        public ObservableCollection<Equipo> Equipos
        {
            get { return _equipos; }
            set { SetProperty(ref _equipos, value); }
        }

        //Funciones

        private async void GetEquipos()
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
    }
}
