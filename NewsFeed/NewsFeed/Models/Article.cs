using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NewsFeed.Models
{
	public class Article
	{
		[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
      
		public string Author { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Url { get; set; }

		public string UrlToImage { get; set; }

		public string PublishedAt { get; set; }
		
		public DateTime PublishedDateTime { get; set; }

		public string PrintableDateTime { get; set; }
        
        public Category Category { get; set; }
    }
}
