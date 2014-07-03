using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using ProgrammingEvents.Core;

namespace ProgrammingEvents.Droid
{
	public class JavaEvent : Java.Lang.Object
	{
		Event _e;

		public JavaEvent(Event e)
		{
			_e = e;
		}

		public Event e {
			get {
				return _e;
			}
		}
	}

	public class EventsAdapter : BaseAdapter
	{
		Context _context;
		EventManager _manager;
		List<Event> _events;

		public EventsAdapter(Context c)
		{
			_context = c;
			_manager = new EventManager (new FileAccessor (c));
		}

		public void UpdateEvents()
		{
			_manager.UpdateData ();
			_events = _manager.GetData ();
			NotifyDataSetChanged ();
		}

		public override int Count {
			get {
				return _events.Count;
			}
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return new JavaEvent (_events [position]);
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				convertView = LayoutInflater
					.From (_context)
					.Inflate (
					Resource.Layout.EventListItemLayout,
					parent,
					false);
			}

			var eventName = convertView.FindViewById<TextView> (Resource.Id.eventName);
			var eventSubtitle = convertView.FindViewById<TextView> (Resource.Id.eventSubtitle);
			var item = (JavaEvent) GetItem (position);

			eventName.Text = item.e.Title;
			eventSubtitle.Text = item.e.DetailLabelText;

			return convertView;
		}
	}
}

