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

        public static SalasManager SalasManager { get; private set; }
        public static LoginManager LoginManager { get; private set; }
        public static MuroManager MuroManager { get; private set; }
        public static PerfilManager PerfilManager { get; private set; }
        public static PartidaManager PartidaManager { get; private set; }
        public static ICredencialesService CredencialesService { get; private set; }
        public static Usuario UsuarioPrincipal { get; set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BaseViewModel>();

            ServicioFake.RellenarDatos();

            CredencialesService = new CredencialesService();

            LoginManager = new LoginManager(new LoginService());
            SalasManager = new SalasManager(new SalasService());
            MuroManager = new MuroManager(new MuroService());
            PerfilManager = new PerfilManager(new PerfilService());
            PartidaManager = new PartidaManager(new PartidaService());

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
                    UsuarioPrincipal = await PerfilManager.GetUsuario();
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
