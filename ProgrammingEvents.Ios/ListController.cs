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

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			_eventManager.UpdateData ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			TableView.Source = new EventTableSource (_eventManager.GetData());

			this.TabBarController.TabBar.Hidden = false;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			var rect = this.TableView.RectForHeaderInSection (1);
			var height = this.TableView.Frame.Size.Height 
				- this.NavigationController.NavigationBar.Frame.Size.Height 
				- this.TabBarController.TabBar.Frame.Size.Height
				- rect.Size.Height;
			rect.Size = new System.Drawing.SizeF (rect.Size.Width, height);
			this.TableView.ScrollRectToVisible (rect, animated);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "EventSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as EventDetailController;
				if (navctlr != null) {
					var source = TableView.Source as EventTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath);
					navctlr.SetEvent (item); // to be defined on the TaskDetailViewController
				}
			}
		}
	}
}
