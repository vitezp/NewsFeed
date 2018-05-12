using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;
using Xamarin.Forms;

namespace NewsFeed
{
	public partial class MainPage : ContentPage
	{
	    public MainPage()
	    {
	        InitializeComponent();
	    }

        private ObservableCollection<Article> _articles = new ObservableCollection<Article>();

        public ObservableCollection<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }

        

	    void OnButtonClicked(object sender, EventArgs args)
	    {
            Console.WriteLine("Button clicked!");
            var article = new Article(){ Author = "Author", Description = "Description", Title = "Title", Url = "Url", UrlToImage = "Image Url"};
            Articles.Add(article);
	    }
	}
}
