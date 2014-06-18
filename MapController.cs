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
		MKMapView map;
		List<Event> _events;
		private EventManager _eventManager;

		public MapController (IntPtr handle) : base (handle)
		{
			_eventManager = new EventManager (new FileAccessor ());
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

			double lat = 30.2652233534254;
			double lon = -97.73815460962083;
			CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
			MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 100, 5000000);

			map.CenterCoordinate = mapCenter;
			map.Region = mapRegion;

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
