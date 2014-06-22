using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamFeed.Core;

namespace XamFeed.Android
{
	[Activity(Label = "XamFeed", MainLauncher = true, Icon = "@drawable/icon")]
	public class FeedActivity : ListActivity
	{
		private FeedRetriever _retriever;
		private RssItem[] _items;

		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);          
			_retriever = new FeedRetriever ();

			_items = await _retriever.GetItems ("http://blog.xamarin.com/feed");

			ListAdapter = new FeedAdapter (this, _items);

		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			var uri = global::Android.Net.Uri.Parse (_items [position].Link);

			var intent = new Intent (Intent.ActionView, uri);
			StartActivity(intent);
		}
	}
}


