using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeed.Models
{
    public class Article
    {
        public string Author { get; set; }
        
		public string Title { get; set; }
        
		public string Description { get; set; }
        
        public string Url { get; set; }
        
		public string UrlToImage { get; set; }
        
		public string PublishedAt { private get; set; }

		public string GetDateTime
		{
			get => GetPrintableDate(PublishedAt);
			set => GetDateTime = value; 
		}

		private static string GetPrintableDate(string publishedAt)
		{
			//converting to dateTime
			var dateTime = Convert.ToDateTime(publishedAt);
			var sb = new StringBuilder();

			if (dateTime.Day < DateTime.Now.Day){
				sb.Append($"{dateTime:dd.MM} ");
			}
			sb.Append($"{dateTime:HH:mm}");
			return sb.ToString();
		}

    }
}
