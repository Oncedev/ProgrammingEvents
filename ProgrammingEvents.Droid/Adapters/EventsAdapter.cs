using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using ProgrammingEvents.Core;
using Newtonsoft.Json;

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
		List<Event> _pastEvents;
		List<Event> _upcomingEvents;

		public EventsAdapter(Context c)
		{
			_context = c;
			_manager = new EventManager (new FileAccessor (c));
		}

		public void UpdateEvents()
		{
			_manager.UpdateData ();
			var events = _manager.GetData ();

			_pastEvents = events.GetPastEvents ();
			_upcomingEvents = events.GetUpcomingEvents ();
			NotifyDataSetChanged ();
		}

		public override int Count {
			get {
				return _pastEvents.Count + _upcomingEvents.Count + 2;
			}
		}

		public override Java.Lang.Object GetItem (int position)
		{
			if (position > 0 && position <= _pastEvents.Count)
				return new JavaEvent (_pastEvents [position - 1]);

			if (position > _pastEvents.Count + 1 && position <= _pastEvents.Count + 1 + _upcomingEvents.Count)
				return new JavaEvent (_upcomingEvents [position - _pastEvents.Count - 2]);

			return null;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (position == 0) {
				var pastLabel = (TextView) LayoutInflater.From(_context).Inflate(Resource.Layout.SeparatorLabel, parent, false);
				pastLabel.Text = "Past";

				return pastLabel;
			}

			if (position == _pastEvents.Count + 1) {
				var upcomingLabel = (TextView) LayoutInflater.From(_context).Inflate(Resource.Layout.SeparatorLabel, parent, false);
				upcomingLabel.Text = "Upcoming";

				return upcomingLabel;
			}

			if (convertView == null) {
				convertView = LayoutInflater
					.From (_context)
					.Inflate (
					Resource.Layout.EventListItem,
					parent,
					false);
			}

			var eventName = convertView.FindViewById<TextView> (Resource.Id.eventName);
			var eventSubtitle = convertView.FindViewById<TextView> (Resource.Id.eventSubtitle);
			var item = (JavaEvent) GetItem (position);

			eventName.Text = item.e.Title;
			eventSubtitle.Text = item.e.DetailLabelText;

			convertView.Click += (sender, e) => {
				var intent = new Intent(_context, typeof(EventActivity));
				intent.PutExtra("event", JsonConvert.SerializeObject(item.e));
				_context.StartActivity(intent);
			};

			return convertView;
		}
	}
}

