using System.Threading.Tasks;
using EscapeRankUI.Estilos;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        private string _tema;
        private bool _modoOscuro;
        private Usuario _usuario;
        public Command LogoutCommand { get; }

        public UsuarioViewModel()
        {
            LogoutCommand = new Command(Logout);

            Task.Run(async () =>
            {
                _tema = await App.CredencialesService.GetTema();

            }).ContinueWith((arg) =>
            {
                if (_tema == "Oscuro")
                {
                    ModoOscuro = true;
                }

            }).Wait();

        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public bool ModoOscuro
        {
            get { return _modoOscuro; }
            set
            {
                _modoOscuro = value;

                if (_modoOscuro)
                {
                    Application.Current.Resources = new Oscuro();
                    App.CredencialesService.GuardarTema("Oscuro");
                }
                else
                {
                    Application.Current.Resources = new Claro();
                    App.CredencialesService.GuardarTema("Claro");
                }
            }
        }

        public async void Logout()
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Cerrar sesión", "¿Seguro de que desea cerrar sesión?", "Si", "No");

            if (respuesta)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
