using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EscapeRankUI.Estilos.Temas;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class BaseViewModel : BindableObject
    {
        private bool _cargando;

        public BaseViewModel()
        {
           // _usuario = ServicioFake.Usuarios.FirstOrDefault<Usuario>((arg) => arg.Id == App.CredentialsService.IdUsuario);
        }

        public bool Cargando
        {
            get { return _cargando; }
            set
            {
                SetProperty(ref _cargando, value);
            }
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
