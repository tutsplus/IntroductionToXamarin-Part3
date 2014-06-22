using System;
using Android.Widget;
using XamFeed.Core;
using Android.App;
using Android.Views;
using Android.OS;
using System.Linq;

namespace XamFeed.Android
{
	public class FeedAdapter : BaseAdapter<RssItem>
	{
		private RssItem[] _items;
		private Activity _context;

		public FeedAdapter( Activity context, RssItem[] items) : base()
		{
			_context = context;
			_items = items;
		}

		public override RssItem this[int position]
		{
			get { return _items[position]; }
		}

		public override int Count
		{
			get { return _items.Count(); }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null)
			{
				view = _context.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem2, null);
			}

			view.FindViewById<TextView>(global::Android.Resource.Id.Text1).Text = _items[position].Title;
			view.FindViewById<TextView>(global::Android.Resource.Id.Text2).Text = string.Format("{0} on {1}", _items[position].Creator, _items[position].PubDate);

			return view;
		}
	}
}

