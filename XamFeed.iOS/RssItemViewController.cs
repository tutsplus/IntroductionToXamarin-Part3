
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using XamFeed.Core;
using System.Linq;

namespace XamFeed.iOS
{
	public class RssItemViewController : UITableViewController
	{
		private FeedRetriever _retriever;
		private RssItem[] _items;
		public RssItemViewController () : base ()
		{
			_retriever = new FeedRetriever ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			_items = await _retriever.GetItems ("http://blog.xamarin.com/feed");
			// Register the TableView's data source
			TableView.Source = new RssItemViewSource (_items);
			TableView.ReloadData ();

		}
	}
}

