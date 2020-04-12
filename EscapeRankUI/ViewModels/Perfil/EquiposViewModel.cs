using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Perfil
{
    public class EquiposViewModel : BaseViewModel
    {
        private ObservableCollection<Equipo> _equipos;

        public EquiposViewModel()
        {
            GetEquipos();
        }

        public ObservableCollection<Equipo> Equipos
        {
            get { return _equipos; }
            set { SetProperty(ref _equipos, value); }
        }

        private async void GetEquipos()
        {
            List<Equipo> equiposCall = Servicios.ServicioFake.Usuarios[0].Equipos; //await App.ProfileManager.GetEquipos();

            Equipos = new ObservableCollection<Equipo>(equiposCall);
        }
      

    }
}
