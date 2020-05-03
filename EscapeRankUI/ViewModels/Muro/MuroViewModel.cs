using System.Collections.Generic;
using System.Collections.ObjectModel;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class MuroViewModel : BaseViewModel
    {
        private ObservableCollection<Noticia> _noticias;

        public ObservableCollection<Noticia> Noticias
        {
            get { return _noticias; }
            set { SetProperty(ref _noticias, value); }
        }

        public async void GetNoticias()
        {
            Cargando = true;

            try
            {
                List<Noticia> noticiasCall = await App.MuroService.GetNoticiasAsync(); //Servicios.ServicioFake.Noticias;
                Noticias = new ObservableCollection<Noticia>(noticiasCall);
            }
            catch(HttpUnauthorizedException)
            {
                ErrorCredenciales();
            }
            finally
            {
                Cargando = false;
            }
        }
    }
}
