// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace ProgrammingEvents
{
	[Register ("EventDetailController")]
	partial class EventDetailController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel AddressText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel DateText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITextView DescriptionText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel NameText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel SiteText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddressText != null) {
				AddressText.Dispose ();
				AddressText = null;
			}
			if (DateText != null) {
				DateText.Dispose ();
				DateText = null;
			}
			if (DescriptionText != null) {
				DescriptionText.Dispose ();
				DescriptionText = null;
			}
			if (NameText != null) {
				NameText.Dispose ();
				NameText = null;
			}
			if (SiteText != null) {
				SiteText.Dispose ();
				SiteText = null;
			}
		}
	}
}
