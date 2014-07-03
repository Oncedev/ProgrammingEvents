using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;
using ProgrammingEvents.Core;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingEvents
{
	partial class MapController : UIViewController
	{
		protected MKMapView map;
		private List<Event> _events;
		private EventManager _eventManager;
		private CLLocationManager _locationManager;

		public MapController (IntPtr handle) : base (handle)
		{
			_eventManager = new EventManager (new FileAccessor ());
			_locationManager = new CLLocationManager ();
		}

		public override void LoadView ()
		{
			map = new MKMapView (UIScreen.MainScreen.Bounds);
			View = map;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			this.TabBarController.TabBar.Hidden = false;
		}

		public override void ViewDidLoad ()
		{
			map.MapType = MKMapType.Standard;
			map.ShowsUserLocation = true;
			map.ZoomEnabled = true;
			map.ScrollEnabled = true;

			CenterMap ();

			var mapDelegate = new MapDelegate ((title) => {
				this.PerformSegue("EventSegue", title);
			});
			map.Delegate = mapDelegate;

			_events = _eventManager.GetData ().Where(x => x.StartDate.Date >= DateTime.Today.Date).ToList();

			_events.ForEach(x => map.AddAnnotation (
				new EventAnnotation (
					x.Title, 
					new CLLocationCoordinate2D() { 
						Latitude=x.Latitude, 
						Longitude= x.Longitude})));

			_locationManager.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) => {CenterMap();};			
		}	

		public void CenterMap() {
			var mapCenter = GetDefaultLocation ();
			var mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 100, 5000000);

			map.CenterCoordinate = mapCenter;
			map.Region = mapRegion;
		}

		public CLLocationCoordinate2D GetDefaultLocation() {
			if (CLLocationManager.LocationServicesEnabled && CLLocationManager.Status == CLAuthorizationStatus.Authorized) {
				return _locationManager.Location.Coordinate;
			}

			// Fallback
			double lat = 30.2652233534254;
			double lon = -97.73815460962083;
			CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
			return mapCenter;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "EventSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as EventDetailController;
				if (navctlr != null) {
					var item = _events.Find (x => x.Title == sender.ToString());
					navctlr.SetEvent (item);
				}
			}
		}
	}
}
