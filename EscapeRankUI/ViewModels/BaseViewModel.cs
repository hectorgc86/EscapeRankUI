using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }
        private bool _cargando;
        private ObservableCollection<Noticia> _noticias;
        private ObservableCollection<Sala> _salas;
        private ObservableCollection<Sala> _salasFiltradas;
        private ObservableCollection<Categoria> _categorias;
        private ObservableCollection<Publico> _publico;
        private ObservableCollection<Dificultad> _dificultades;

        public event PropertyChangedEventHandler PropertyChanged;


        public BaseViewModel()
        {
           // _usuario = ServicioFake.Usuarios.FirstOrDefault<Usuario>((arg) => arg.Id == App.CredentialsService.IdUsuario);
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

        public ObservableCollection<Noticia> Noticias
        {
            get { return _noticias; }
            set { SetProperty(ref _noticias, value); }
        }

      
        public ObservableCollection<Sala> Salas
        {
            get { return _salas; }
            set { SetProperty(ref _salas, value); }
        }

        public ObservableCollection<Sala> SalasFiltradas
        {
            get { return _salasFiltradas; }
            set { SetProperty(ref _salasFiltradas, value); }
        }

        public ObservableCollection<Dificultad> Dificultades
        {
            get { return _dificultades; }
            set { SetProperty(ref _dificultades, value); }
        }

        public ObservableCollection<Publico> Publico
        {
            get { return _publico; }
            set { SetProperty(ref _publico, value); }
        }

        public ObservableCollection<Categoria> Categorias
        {
            get { return _categorias; }
            set { SetProperty(ref _categorias, value); }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

    }
}
