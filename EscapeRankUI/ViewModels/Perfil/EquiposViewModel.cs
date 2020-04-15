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
            GetEquipos();
            VerEquipoCommand = new Command<Equipo>(VerEquipo);
        }

        //Getters & Setters

        public ICommand VerEquipoCommand { get; set; }

        public ObservableCollection<Equipo> Equipos
        {
            get { return _equipos; }
            set { SetProperty(ref _equipos, value); }
        }

        //Funciones

        private async void GetEquipos()
        {
            List<Equipo> equiposCall = await App.PerfilManager.GetEquiposAsync(); //Servicios.ServicioFake.Usuarios[0].Equipos; 

            Equipos = new ObservableCollection<Equipo>(equiposCall);
        }

        private async void VerEquipo(Equipo equipoSeleccionado)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EquipoDetallePage(equipoSeleccionado));
        }


    }
}
