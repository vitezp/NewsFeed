using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Views;

namespace NewsFeed.Models
{

	public class DetailPageMenuItem
	{
	    public DetailPageMenuItem()
	    {
	        TargetType = typeof(DetailPageDetail);
	    }
		public int Id { get; set; }
		public Category Category { get; set; }
	    public string Label { get; set; }
        public Type TargetType { get; set; }
	}
}