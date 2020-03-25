using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Servicios;
using EscapeRankUI.Views.Login;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EscapeRankUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MainService>();
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
