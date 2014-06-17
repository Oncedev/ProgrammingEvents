using System;
using MonoTouch.UIKit;
using ProgrammingEvents.Core;

namespace ProgrammingEvents
{
	public class EventDetailController : UITableViewController
	{
		public Event CurrentEvent {
			get;
			set;
		}

		public EventDetailController (IntPtr handle) : base (handle)
		{

		}
	}
}

