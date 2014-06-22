using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using XamFeed.Core;
using MonoTouch.Foundation;

namespace XamFeed.iOS
{
	public class RssItemViewSource : UITableViewSource
	{
		private RssItem[] _items;

		public RssItemViewSource (RssItem[] items)
		{
			_items = items;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return _items.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (RssItemViewCell.Key) as RssItemViewCell;
			if (cell == null)
				cell = new RssItemViewCell ();

			// TODO: populate the cell with the appropriate data based on the indexPath

			cell.TextLabel.Text = _items[indexPath.Row].Title;
			cell.DetailTextLabel.Text = string.Format ("{0} on {1}", _items [indexPath.Row].Creator, _items [indexPath.Row].PubDate);

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var item = _items [indexPath.Row];

			var url = new NSUrl (item.Link);
			UIApplication.SharedApplication.OpenUrl (url);
		}
	}

}

