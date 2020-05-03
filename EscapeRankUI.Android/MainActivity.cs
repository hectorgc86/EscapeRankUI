using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Plugin.FacebookClient;
using Android.Content;
using Java.Security;
using System;
using Xamarin.Facebook;

namespace EscapeRankUI.Droid
{
    [Activity(Theme = "@style/MainTheme", 
              MainLauncher = false, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(Application);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           
            //FacebookClientManager.Initialize(this);

            FormsMaterial.Init(this, savedInstanceState);
            Forms.SetFlags("UseLegacyRenderers");
            Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            FacebookClientManager.OnActivityResult(requestCode, resultCode, intent);
        }

        public static void PrintHashKey(Context pContext)
        {
            try
            {
                PackageInfo info = Android.App.Application.Context.PackageManager.GetPackageInfo(Android.App.Application.Context.PackageName, PackageInfoFlags.Signatures);
                foreach (var signature in info.Signatures)
                {
                    MessageDigest md = MessageDigest.GetInstance("SHA");
                    md.Update(signature.ToByteArray());

                    System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(md.Digest()));
                }
            }
            catch (NoSuchAlgorithmException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}