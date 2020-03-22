using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }

        private bool _cargando;
        //private Usuario _usuario;
        //private ObservableCollection<Equipo> _listaEquipos;
        //private ObservableCollection<Usuario> _listaAmigos;

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

        string title = string.Empty;


        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string icon = string.Empty;

  
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        public BaseViewModel()
        {
            // User = FakeData.Users.FirstOrDefault<User>((arg) => arg.IdUsuarios == App.CredentialsService.IdUsuario);

        }

       
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

     

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        //Método para actualizar los cambios
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }


    }
}
