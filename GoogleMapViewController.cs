using CoreGraphics;
using Google.Maps;
using UIKit;

namespace PikkartGoogleMaps
{
    public class GoogleMapViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var camera = CameraPosition.FromCamera(48, 8, 6);
            var mapView = MapView.FromCamera(CGRect.Empty, camera);

            View = mapView;
        }
    }
}