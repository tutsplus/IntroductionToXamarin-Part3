using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace XamFeed.iOS
{
	public class RssItemViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("FeedItemViewControllerCell");

		public RssItemViewCell () : base (UITableViewCellStyle.Subtitle, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

