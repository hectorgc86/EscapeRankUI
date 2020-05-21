using System.Threading.Tasks;
using EscapeRankUI.Estilos;
using EscapeRankUI.Modelos;
using EscapeRankUI.Views;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {

        //Variables

        string _tema;
        private bool _modoOscuro;
        public Usuario Usuario { get; set; }
        public Command LogoutCommand { get; }

        //Constructor

        public UsuarioViewModel()
        {
            LogoutCommand = new Command(Logout);

            Usuario = App.UsuarioPrincipal;

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

        //Getters & Setters

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

        //Funciones

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
