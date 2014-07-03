using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using MonoTouch.ObjCRuntime;

namespace ProgrammingEvents
{
	partial class SiteController : UIViewController
	{
		UIWebView WebView;
		LoadingOverlay loadingOverlay;
		NSUrl URL;

		public SiteController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();

			var length = MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (
				TopLayoutGuide.Handle,
				(new Selector("length")).Handle);

			WebView.ScrollView.ContentInset = new UIEdgeInsets (length, 0, 0, 0);
		}

		public override void ViewDidLoad ()
		{
			WebView = new UIWebView (View.Bounds);

			loadingOverlay = new LoadingOverlay (UIScreen.MainScreen.Bounds);

			WebView.LoadStarted += (sender, e) => {
				View.Add (loadingOverlay);
			};				

			WebView.LoadFinished += (sender, e) => {
				loadingOverlay.Hide ();
			};

			WebView.LoadRequest(new NSUrlRequest(URL));
			WebView.ScalesPageToFit = true;

			View.AddSubview(WebView);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public void SetURL(string url) {
			URL = new NSUrl (url);
		}
	}
}
