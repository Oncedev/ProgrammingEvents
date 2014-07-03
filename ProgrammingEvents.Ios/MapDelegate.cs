using System;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace ProgrammingEvents
{
	public class MapDelegate : MKMapViewDelegate
	{
		string pId = "EventAnnotation";
		Action<NSString> _detailEvent;

		public MapDelegate (Action<NSString> detailEvent)
		{
			_detailEvent = detailEvent;
		}

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
		{
			if (annotation is MKUserLocation)
				return null; 

			// create pin annotation view
			var pinView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);

			if (pinView == null)
				pinView = new MKPinAnnotationView (annotation, pId);

			((MKPinAnnotationView)pinView).PinColor = MKPinAnnotationColor.Red;
			pinView.CanShowCallout = true;
			pinView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);

			return pinView;
		}

		public override void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
		{
			var eventAnnotation = view.Annotation as EventAnnotation;
			_detailEvent (new NSString(eventAnnotation.Title));
		}
	}
}

