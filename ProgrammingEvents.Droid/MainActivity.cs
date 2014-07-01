using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace ProgrammingEvents.Droid
{
	[Activity (Label = "Events", MainLauncher = true)]
	public class MainActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			var viewPager = FindViewById<ViewPager> (Resource.Id.viewPager);

			var listTab = ActionBar.NewTab ();
			listTab.SetText ("List");
			listTab.TabSelected += (sender, e) => {
				viewPager.SetCurrentItem(0, smoothScroll:true);
			};

			var mapTab = ActionBar.NewTab ();
			mapTab.SetText ("Map");
			mapTab.TabSelected += (sender, e) => {
				viewPager.SetCurrentItem(1, smoothScroll:true);
			};

			ActionBar.AddTab (listTab);
			ActionBar.AddTab (mapTab);

			viewPager.PageSelected += (object sender, ViewPager.PageSelectedEventArgs e) => {
				ActionBar.SetSelectedNavigationItem(e.Position);
			};
			viewPager.Adapter = new MainActivityAdapter (SupportFragmentManager);
		}
	}
}


