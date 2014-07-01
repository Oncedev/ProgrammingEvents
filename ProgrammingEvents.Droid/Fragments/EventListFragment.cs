
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

			// TODO
			var strings = new string[] { "Event 1", "Event 2", "Event 3" };

			ListAdapter = new ArrayAdapter<string> (
				Activity,
				Android.Resource.Layout.SimpleListItem1,
				strings);
		}
	}
}
	