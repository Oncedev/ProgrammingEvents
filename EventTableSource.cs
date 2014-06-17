using System;
using System.Collections.Generic;
using ProgrammingEvents.Core;
using MonoTouch.UIKit;

namespace ProgrammingEvents
{
	public class EventTableSource : UITableViewSource
	{
		private List<Event> _events;
		string cellIdentifier = "eventcell";

		public EventTableSource (List<Event> events)
		{
			_events = events;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _events.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);
			var item = _events[indexPath.Row];
			cell.TextLabel.Text = item.Title;
			cell.DetailTextLabel.Text = item.Address;

			return cell;
		}

		public Event GetItem(int id) {
			return _events[id];
		}
	}
}

