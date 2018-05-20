using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.API;
using NewsFeed.Models;
using Xamarin.Forms;
using NewsFeed.ViewModels;
using System.Collections;

namespace NewsFeed
{
	public partial class MainPage : ContentPage
	{

		//LoadNewsViewModel loadNewsViewModel;

		public MainPage()
		{
			InitializeComponent();

			var loadNewsViewModel = new LoadNewsViewModel();

			BindingContext = loadNewsViewModel;
            
            ArticlesList.IsPullToRefreshEnabled = false;
			ArticlesList.RefreshCommand = loadNewsViewModel.PullToRefreshCommand;
            
			ArticlesList.ItemTapped += (sender, e) =>
            {
				ArticlesList.SelectedItem = null;
			};

		}

		//ObservableCollection<Article> ArticleList; 


		protected async override void OnAppearing()
        {
			
			base.OnAppearing();

			List<Article> loadedArticles = await App.Database.GetArticlesAsync();

            if (loadedArticles.Count == 0)
			{
				loadedArticles = await Fetch.FetchNewsFeed();
				await App.Database.InsertArticleAsync(loadedArticles);
			}

			ArticlesList.ItemsSource = loadedArticles;
                                  
        }

		void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var article = e.SelectedItem as Article;

            if (article == null)
            {
                return;
            }

            var inAppBrowser = new InAppBrowser(article.Url);
            inAppBrowser.BindingContext = article;

			Navigation.PushModalAsync(inAppBrowser);
        }
        
	}
}
