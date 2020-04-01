using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels.Muro
{
    public class MuroViewModel : BaseViewModel
    {
        public MuroViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetNoticias();
        }

        private async void GetNoticias()
        {
            if (Cargando)
                return;

                Cargando = true;

            List<Noticia> noticiasCall = Servicios.ServicioFake.Noticias;    //await App.WallManager.GetNewsAsync();
            Noticias = new ObservableCollection<Noticia>(noticiasCall);
        }

    }
}
