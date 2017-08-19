using CoreGraphics;
using CoreLocation;
using Foundation;
using Google.Maps;
using Pikkart.ArSdk.Geo;
using UIKit;

namespace PikkartGoogleMaps
{
    public class PikkartMapViewController : PKTGeoMainController, IPKTIArGeoListener, IMapViewDelegate
    {
        private IMapViewDelegate _pikkartMapViewDelegate;

        public PikkartMapViewController()
            : this(new PKTMarkerViewAdapter(new CGSize(30, 45)), new PKTMarkerViewAdapter(new CGSize(40, 40)))
        {

        }

        public PikkartMapViewController(PKTMarkerViewAdapter geoViewAdapter, PKTMarkerViewAdapter mapViewAdapter)
            : base(geoViewAdapter, mapViewAdapter)
        {
            var googleMap = ValueForKey(new NSString("googlemap"));
            var mapView = googleMap.ValueForKey(new NSString("mapView"));
            var view = (MapView)mapView;

            _pikkartMapViewDelegate = view.Delegate;

            // override delegate so we can use Google Map events
            view.Delegate = this;
        }

        #region PikkartProtocol

        [Export("onGeoElement:Click:")]
        public void GeoElementClicked(NSObject nsobject, UIView view)
        {
            var geoElement = nsobject as PKTGeoElement;
            // do something
        }

        [Export("onGeoLocationChanged:")]
        public void GeoLocationChanged(NSObject nsobject)
        {
            var location = nsobject as PKTGeoLocation;
            // do something
        }

        [Export("onMapOrCameraClicked")]
        public void MapOrCameraClicked()
        {
            // do something
        }

        #endregion

        #region GoogleMapsProtocol

        [Export("mapView:didChangeCameraPosition:")]
        public void DidChangeCameraPosition(MapView mapView, CameraPosition position)
        {
            var visibleRegion = mapView.Projection.VisibleRegion;
            var center = mapView.Projection.CoordinateForPoint(mapView.Center);
            var northEast = visibleRegion.FarRight;
            var southWest = visibleRegion.NearLeft;

            // do something
        }

        [Export("mapView:didTapAtCoordinate:")]
        public void DidTapAtCoordinate(MapView mapView, CLLocationCoordinate2D coordinate)
        {
            _pikkartMapViewDelegate.DidTapAtCoordinate(mapView, coordinate); // this will call MapOrCameraClicked
        }

        [Export("mapView:didTapMarker:")]
        public bool TappedMarker(MapView mapView, Marker marker)
        {
            return _pikkartMapViewDelegate.TappedMarker(mapView, marker); // this will call GeoElementClicked
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pikkartMapViewDelegate.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}