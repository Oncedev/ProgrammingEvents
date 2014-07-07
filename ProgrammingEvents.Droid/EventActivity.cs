
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Views;
using Android.Widget;

using Newtonsoft.Json;
using ProgrammingEvents.Core;

namespace ProgrammingEvents.Droid
{
	[Activity (Label = "Event")]			
	public class EventActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Event);

			var serializedData = Intent.GetStringExtra ("event");
			var eventData = JsonConvert.DeserializeObject<Event> (serializedData);

			FindViewById<TextView> (Resource.Id.nameLabel).Text = eventData.Title;
			FindViewById<TextView> (Resource.Id.dateLabel).Text = eventData.DateIntervalText;
			FindViewById<TextView> (Resource.Id.siteLabel).Text = eventData.Site;
			FindViewById<TextView> (Resource.Id.locationLabel).Text = eventData.Address;

			FindViewById<TextView>(Resource.Id.otherInfoLabel).Text = eventData.Description;
		}
	}
}

