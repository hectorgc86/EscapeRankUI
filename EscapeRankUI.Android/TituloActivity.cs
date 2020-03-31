using Android.App;
using Android.Content.PM;
using Android.OS;


namespace EscapeRankUI.Droid
{
    [Activity(Theme = "@style/TituloTheme",
                 MainLauncher = true,
                 NoHistory = true,
                 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class TituloActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));

        }
    }
}