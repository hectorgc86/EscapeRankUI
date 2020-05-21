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
        private Sala _salaSeleccionada;

        public bool Cargando
        {
            get { return _cargando; }
            set { SetProperty(ref _cargando, value); }
        }

        public Sala SalaSeleccionada
        {
            get { return _salaSeleccionada; }
            set { SetProperty(ref _salaSeleccionada, value); }
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

        protected async void ErrorCredenciales() {

            if (Cargando)
            {
                await Application.Current.MainPage.DisplayAlert("Su sesión ha caducado", "Debe volver a hacer login", "Ok");
                Application.Current.MainPage = new NavigationPage(new LoginPage());

                Cargando = false;
            }
        }

        protected async void VerSala()
        {
            TabbedPage tp = new TabbedPage
            {
                BarBackgroundColor = (Color)Utils.GetResourceValue("azul1"),
                BarTextColor = (Color)Utils.GetResourceValue("blanco1"),
                UnselectedTabColor = (Color)Utils.GetResourceValue("gris2"),
                Title = SalaSeleccionada.Nombre,
                Children = { new SalaDetallePage(SalaSeleccionada), new SalaRankingPage(SalaSeleccionada) }
            };

            await Application.Current.MainPage.Navigation.PushAsync(tp);
        }
    }
}
