using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace EscapeRankUI.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");

            Xamarin.Forms.Forms.Init();

            Xamarin.Forms.FormsMaterial.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
