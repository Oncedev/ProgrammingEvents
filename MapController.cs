using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace ProgrammingEvents
{
	partial class MapController : UIViewController
	{
		MKMapView map;

		public MapController (IntPtr handle) : base (handle)
		{
		}

		public override void LoadView ()
		{
			map = new MKMapView (UIScreen.MainScreen.Bounds);
			View = map;
		}

		public override void ViewDidLoad ()
		{
			map.MapType = MKMapType.Standard;
			map.ShowsUserLocation = true;
			map.ZoomEnabled = true;
			map.ScrollEnabled = true;

			double lat = 30.2652233534254;
			double lon = -97.73815460962083;
			CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
			MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 100, 100);
			map.CenterCoordinate = mapCenter;
			map.Region = mapRegion;
		}
	}
}
