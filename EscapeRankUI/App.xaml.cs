using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscapeRankUI.Views;
using EscapeRankUI.ViewModels;
using EscapeRankUI.Modelos;
using EscapeRankUI.Servicios;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EscapeRankUI
{
    public partial class App : Application
    {
        public static Usuario UsuarioPrincipal { get; set; }

        public static ILoginService LoginService { get; private set; }
        public static IMuroService MuroService { get; private set; }
        public static ISalasService SalasService { get; private set; }
        public static IPartidaService PartidaService { get; private set; }
        public static IHistorialService HistorialService { get; private set; }
        public static IPerfilService PerfilService { get; private set; }
        public static ICredencialesService CredencialesService { get; private set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BaseViewModel>();

            //ServicioFake.RellenarDatos();

            LoginService = new LoginService();
            MuroService = new MuroService();
            SalasService = new SalasService();
            PartidaService = new PartidaService();
            HistorialService = new HistorialService();
            PerfilService = new PerfilService();
            CredencialesService = new CredencialesService();

            bool existenCredenciales = false;

            Task.Run(async () =>
            {
                existenCredenciales = await CredencialesService.ComprobarCredenciales();

            }).ContinueWith((arg) => {

                if (existenCredenciales)
                {
                    Task.Run(async () =>
                    {
                       UsuarioPrincipal = await PerfilService.GetUsuarioAsync();
                    }).Wait();
                    MainPage = new AppShell();
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }).Wait();
        }
    }
}
