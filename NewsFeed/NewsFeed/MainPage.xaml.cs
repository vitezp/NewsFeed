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

namespace NewsFeed
{
	public partial class MainPage : ContentPage
	{


		public MainPage()
		{
			InitializeComponent();

			var loadNewsiewModel = new LoadNewsViewModel();

			BindingContext = loadNewsiewModel;
            
			Articles.IsPullToRefreshEnabled = true;
			Articles.RefreshCommand = loadNewsiewModel.PullToRefreshCommand;
            
			Articles.ItemTapped += (sender, e) =>
            {
				Articles.SelectedItem = null;
			};

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
