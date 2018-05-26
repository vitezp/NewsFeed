using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Views
{

    public class DetailPageMenuItem
    {
        public DetailPageMenuItem()
        {
            TargetType = typeof(DetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}