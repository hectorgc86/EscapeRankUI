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
        public static LoginManager LoginManager { get; private set; }
        public static MuroManager MuroManager { get; private set; }
        public static SalasManager SalasManager { get; private set; }
        public static PartidaManager PartidaManager { get; private set; }
        public static HistorialManager HistorialManager { get; private set; }
        public static PerfilManager PerfilManager { get; private set; }

        public static ICredencialesService CredencialesService { get; private set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BaseViewModel>();

            //ServicioFake.RellenarDatos();

            CredencialesService = new CredencialesService();

            LoginManager = new LoginManager(new LoginService());
            MuroManager = new MuroManager(new MuroService());
            SalasManager = new SalasManager(new SalasService());
            PartidaManager = new PartidaManager(new PartidaService());
            HistorialManager = new HistorialManager(new HistorialService());
            PerfilManager = new PerfilManager(new PerfilService());

            Login login = new Login();

            Task.Run(async () =>
            {

            }).ContinueWith(async (arg) => {
                if (login != null && login.TokenAcceso != null)
                {
                    // await CredencialesService.SaveToken(login.TokenAcceso);
                }
                else
                {
                    await CredencialesService.DeleteCredentials();
                }
            }).Wait();

            if (CredencialesService.DoCredentialsExist())
            {
                Task.Run(async () =>
                {
                    UsuarioPrincipal = await PerfilManager.GetUsuarioAsync();
                }).Wait();
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
