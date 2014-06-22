using System;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace XamFeed.Core
{
	public class FeedRetriever
	{
		public async Task<RssItem[]> GetItems(string feedUrl) 
		{
			using (var client = new HttpClient())
			{
				var xmlFeed = await client.GetStringAsync(feedUrl);
				var doc = XDocument.Parse(xmlFeed);
				XNamespace dc = "http://purl.org/dc/elements/1.1/";

				var items = (from item in doc.Descendants("item")
					select new RssItem
					{
						Title = item.Element("title").Value,
						PubDate = item.Element("pubDate").Value,
						Creator = item.Element(dc + "creator").Value,
						Link = item.Element("link").Value
					}).ToArray();

				return items;
			}
		}
	}
}

