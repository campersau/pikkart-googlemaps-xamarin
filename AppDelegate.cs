using Foundation;
using UIKit;

namespace PikkartGoogleMaps
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Google.Maps.MapServices.ProvideAPIKey("< Google Maps API Key >");

            Pikkart.ArSdk.Geo.PKTGeoMainController.SetGoogleMapsKey("< Google Maps API Key >");

            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            //Window.RootViewController = new GoogleMapViewController();
            Window.RootViewController = new PikkartMapViewController();

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}


