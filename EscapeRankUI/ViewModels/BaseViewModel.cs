using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using EscapeRankUI.Estilos;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class BaseViewModel : BindableObject
    {
        private bool _cargando;

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

        public async void ErrorCredenciales() {

            if (Cargando)
            {
                await Application.Current.MainPage.DisplayAlert("Su sesión ha caducado", "Debe volver a hacer login", "Ok");
                Application.Current.MainPage = new NavigationPage(new LoginPage());

                Cargando = false;
            }
        }
    }
}
