
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.OS;
using Android.Widget;

namespace ProgrammingEvents.Droid
{
	public class EventListFragment : ListFragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			var adapter = new EventsAdapter (Activity);
			ListAdapter = adapter;

			adapter.UpdateEvents ();
		}
	}
}
	