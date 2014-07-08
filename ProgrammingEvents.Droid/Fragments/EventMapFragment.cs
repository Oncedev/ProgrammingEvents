
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Android.Gms.Maps;
using Android.Gms.Maps.Model;

using ProgrammingEvents.Core;
using Newtonsoft.Json;

namespace ProgrammingEvents.Droid
{
	public class EventMapFragment : SupportMapFragment
	{
		List<Marker> _markers = new List<Marker>();
		List<Event> _events = new List<Event>();

		public override void OnStart ()
		{
			base.OnStart ();

			if (_markers.Count == 0) {
				var eventsMan = new EventManager(new FileAccessor(Activity));
				_events = eventsMan.GetData();

				_markers = _events.Select (
					ev => Map.AddMarker (
						new MarkerOptions ()
						.SetPosition (
							new LatLng (
								ev.Latitude,
								ev.Longitude))
						.SetTitle (
							ev.Title)))
					.ToList ();
			}

			Map.InfoWindowClick += (object sender, GoogleMap.InfoWindowClickEventArgs e) => {
				var index = _markers.FindIndex ((Marker other) => other.Id == e.P0.Id);
				var ev = _events [index];

				var intent = new Intent (Activity, typeof(EventActivity));
				intent.PutExtra ("event", JsonConvert.SerializeObject (ev));
				StartActivity (intent);
			};
		}
	}
}

