using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;

using Android.Gms.Maps;
using Android.Gms.Maps.Model;

using ProgrammingEvents.Core;
using Newtonsoft.Json;

namespace ProgrammingEvents.Droid
{
	[Activity (Label = "Events", MainLauncher = true)]
	public class MainActivity : FragmentActivity, GoogleMap.IOnInfoWindowClickListener
	{
		List<Marker> _markers = new List<Marker>();
		List<Event> _events = new List<Event>();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			var viewPager = FindViewById<ViewPager> (Resource.Id.viewPager);

			var listTab = ActionBar.NewTab ();
			listTab.SetText ("List");
			listTab.TabSelected += (sender, e) => {
				viewPager.SetCurrentItem(0, smoothScroll:true);
			};

			var adapter = new MainActivityAdapter (SupportFragmentManager);

			var mapTab = ActionBar.NewTab ();
			mapTab.SetText ("Map");
			mapTab.TabSelected += (sender, e) => {
				viewPager.SetCurrentItem(1, smoothScroll:true);

				if (_markers.Count == 0) {
					var mapFrag = (SupportMapFragment) adapter.GetItem(1);
					var eventsMan = new EventManager(new FileAccessor(this));
					_events = eventsMan.GetData();

					foreach (var ev in _events)
						_markers.Add(
							mapFrag.Map.AddMarker(
								new MarkerOptions()
								.SetPosition(new LatLng(ev.Latitude, ev.Longitude))
								.SetTitle(ev.Title)));

					mapFrag.Map.SetOnInfoWindowClickListener(this);
				}
			};

			ActionBar.AddTab (listTab);
			ActionBar.AddTab (mapTab);

			viewPager.PageSelected += (object sender, ViewPager.PageSelectedEventArgs e) => {
				ActionBar.SetSelectedNavigationItem(e.Position);
			};

			viewPager.Adapter = adapter;
		}

		public void OnInfoWindowClick(Marker m)
		{
			var index = _markers.FindIndex ((Marker other) => other.Id == m.Id);
			var ev = _events [index];

			var intent = new Intent (this, typeof(EventActivity));
			intent.PutExtra ("event", JsonConvert.SerializeObject (ev));
			StartActivity (intent);
		}
	}
}


