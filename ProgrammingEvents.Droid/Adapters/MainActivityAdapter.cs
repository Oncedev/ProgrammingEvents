using System;
using Android.Support.V4.App;

namespace ProgrammingEvents.Droid
{
	public class MainActivityAdapter : FragmentStatePagerAdapter
	{
		EventListFragment eventList = null;
		EventListFragment map = null;

		public MainActivityAdapter(FragmentManager fm) : base(fm)
		{
		}

		public override int Count {
			get {
				return 2;
			}
		}

		public override Fragment GetItem (int position)
		{
			switch (position) {
			case 0:
				if (eventList == null)
					eventList = new EventListFragment ();

				return eventList;
			case 1:
				if (map == null)
					map = new EventListFragment ();

				return map; // Change this later
			default:
				return null;
			}
		}
	}
}

