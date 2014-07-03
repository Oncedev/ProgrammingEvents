using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ProgrammingEvents.Core;

namespace ProgrammingEvents
{
	public partial class ProgrammingEventsViewController : UITabBarController
	{
		UIViewController tabList, tabMap;

		public ProgrammingEventsViewController ()
		{

		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			var eventManager = new EventManager (new FileAccessor ());

			eventManager.UpdateData ();

			var events = eventManager.GetData ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

