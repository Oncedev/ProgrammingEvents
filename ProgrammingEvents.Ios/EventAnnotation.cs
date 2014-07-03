using System;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;

namespace ProgrammingEvents
{
	public class EventAnnotation : MKAnnotation
	{
		string title;
		CLLocationCoordinate2D coord;

		public EventAnnotation (string title,
			CLLocationCoordinate2D coord)
		{
			this.title = title;
			this.coord = coord;
		}

		public override string Title {
			get {
				return title;
			}
		}

		public override CLLocationCoordinate2D Coordinate {
			get {
				return coord;
			}
			set {
				// call WillChangeValue and DidChangeValue to use KVO with
				// an MKAnnotation so that setting the coordinate on the
				// annotation instance causes the associated annotation
				// view to move to the new location.

				WillChangeValue ("coordinate");
				coord = value;
				DidChangeValue ("coordinate");
			}
		}
			
	}
}

