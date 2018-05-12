using Xamarin.Forms;

namespace NewsFeed.Models
{
	public class Category
    {
		public Category()
        {
            ;
        }
		public Category(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public string Name { set; get; }

        public string Color { set; get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
