using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class MuroViewModel : BaseViewModel
    {
        private ObservableCollection<Noticia> _noticias;

        public MuroViewModel()
        {
            GetNoticias();
        }

        public ObservableCollection<Noticia> Noticias
        {
            get { return _noticias; }
            set { SetProperty(ref _noticias, value); }
        }


        private async void GetNoticias()
        {
            List<Noticia> noticiasCall = await App.MuroManager.GetNoticiasAsync(); //Servicios.ServicioFake.Noticias;
            Noticias = new ObservableCollection<Noticia>(noticiasCall);
        }

    }
}
