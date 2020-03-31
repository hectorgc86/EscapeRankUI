using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        string title, icon;
        private bool _cargando;
        //private Usuario _usuario;
        //private ObservableCollection<Equipo> _listaEquipos;
        //private ObservableCollection<Usuario> _listaAmigos;

        public BaseViewModel()
        {
            // User = FakeData.Users.FirstOrDefault<User>((arg) => arg.IdUsuarios == App.CredentialsService.IdUsuario);
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        public bool Cargando
        {
            set
            {
                _cargando = value;
                OnPropertyChanged("Cargando");

            }
            get
            {
                return _cargando;
            }
        }


        /*
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public ObservableCollection<Equipo> ListaEquipos
        {
            set{SetProperty(ref _listaEquipos, value);}
            get{ return _listaEquipos; }
        }

        public ObservableCollection<Usuario> ListaAmigos
        {
            get { return _listaAmigos; }
            set { SetProperty(ref _listaAmigos, value); }
        }
        
    */

        protected bool SetProperty<T>(
           ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
