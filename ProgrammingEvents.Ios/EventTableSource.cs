using System;
using System.Collections.Generic;
using ProgrammingEvents.Core;
using MonoTouch.UIKit;
using System.Linq;
using MonoTouch.Foundation;

namespace ProgrammingEvents
{
	public class EventTableSource : UITableViewSource
	{
		private List<Event> _events;
		string cellIdentifier = "eventcell";
		Dictionary<string, List<Event>> items;

		public EventTableSource (List<Event> events)
		{
			_events = events;

			var pastEvents = _events.Where (x => x.StartDate.Date < DateTime.Today).OrderBy(x => x.StartDate).ToList();
			var upcomingEvents = _events.Where (x => x.StartDate.Date >= DateTime.Today).OrderBy(x => x.StartDate).ToList();

			items = new Dictionary<string, List<Event>> ();

			items.Add ("Past", pastEvents);
			items.Add ("Upcoming", upcomingEvents);
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return items.Keys.Count;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items [items.Keys.ToList() [section]].Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);
			var item = items [items.Keys.ToList() [indexPath.Section]] [indexPath.Row];
			cell.TextLabel.Text = item.Title;

			var date = item.StartDate == item.EndDate ? item.StartDate.ToShortDateString() : item.StartDate.ToShortDateString() + " - " + item.EndDate.ToShortDateString();
			cell.DetailTextLabel.Text = date + " at " + item.Address;

			return cell;
		}			

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return items.Keys.ToList() [section];
		}

		public Event GetItem(NSIndexPath indexPath) {
			return items [items.Keys.ToList () [indexPath.Section]] [indexPath.Row];
		}
	}
}

