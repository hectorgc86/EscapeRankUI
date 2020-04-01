using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Views.Login;
using EscapeRankUI.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EscapeRankUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BaseViewModel>();

            Servicios.ServicioFake.RellenarDatos();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
