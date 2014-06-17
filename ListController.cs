using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using ProgrammingEvents.Core;

namespace ProgrammingEvents
{
	partial class ListController : UITableViewController
	{
		private EventManager _eventManager;

		public ListController (IntPtr handle) : base (handle)
		{
			_eventManager = new EventManager (new FileAccessor ());
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			TableView.Source = new EventTableSource (_eventManager.GetData());
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "EventSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as EventDetailController;
				if (navctlr != null) {
					var source = TableView.Source as EventTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
				}
			}
		}
	}
}
