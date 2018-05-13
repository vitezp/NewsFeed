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

	}
}
