using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.FacebookClient;
using UIKit;

namespace EscapeRankUI.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            Xamarin.Forms.FormsMaterial.Init();

            LoadApplication(new App());

            FacebookClientManager.Initialize(app, options);
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            return base.FinishedLaunching(app, options);
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
            FacebookClientManager.OnActivated();
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return FacebookClientManager.OpenUrl(app, url, options);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            return FacebookClientManager.OpenUrl(application, url, sourceApplication, annotation);
        }

       
    }
}
