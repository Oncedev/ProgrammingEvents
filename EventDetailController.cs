using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using ProgrammingEvents.Core;

namespace ProgrammingEvents
{
	partial class EventDetailController : UITableViewController
	{
		public Event Event {
			get;
			set;
		}

		public EventDetailController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			NameText.Text = Event.Title;

			DateText.Text = Event.StartDate.ToShortDateString() + " - " + Event.EndDate.ToShortDateString();
			SiteText.Text = Event.Site;
			AddressText.Text = Event.Address;
			DescriptionText.Text = Event.Description;

			this.TabBarController.TabBar.Hidden = true;
		}

		public void SetEvent(Event currentEvent) {
			Event = currentEvent;
		}
	}
}
