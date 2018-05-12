using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.API;
using NewsFeed.Models;
using Xamarin.Forms;

namespace NewsFeed
{
	public partial class MainPage : ContentPage
	{

	    private ObservableCollection<Article> _articles = new ObservableCollection<Article>();

        public MainPage()
        {
            BindingContext = this;
	        InitializeComponent();
            
           // OnButtonClicked(null, null);
	       // OnButtonClicked(null, null);
        }



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
            // var article = new Article(){ Author = "Author", Description = "Description", Title = "Title", Url = "Url", UrlToImage = "Image Url"};
	        Task.Factory.StartNew(async () =>
	        {
	            var news = await NewsService.GetNews();
                news.Articles.ForEach( a => Articles.Add(a) );
	            OnPropertyChanged();
            });
            // Articles.Add(article);
           
	    }
	}
}
