using EscapeRankUI.Modelos;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class AmigoDetalleViewModel : BaseViewModel
    {
        private Amigo _amigo;

        public AmigoDetalleViewModel(Amigo amigoSeleccionado)
        {
            GetAmigo(amigoSeleccionado);
        }

        public Amigo Amigo
        {
            get { return _amigo; }
            set { SetProperty(ref _amigo, value); }
        }

        public async void GetAmigo(Amigo amigoSeleccionado)
        {
            Cargando = true;

            try
            {
                Amigo = await App.PerfilService.GetAmigoAsync(amigoSeleccionado.Id);
            }
            catch (HttpUnauthorizedException)
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
