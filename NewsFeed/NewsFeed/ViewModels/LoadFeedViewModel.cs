using System;
using System.Windows.Input;
using Xamarin.Forms;
using NewsFeed.API;
using NewsFeed.Models;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace NewsFeed.ViewModels
{
    public class LoadNewsViewModel : INotifyPropertyChanged
    {

		ObservableCollection<Article> _articles = new ObservableCollection<Article>();

		public INavigation Navigation;
        public ICommand PullToRefreshCommand { get; private set; }

        private bool _isRefreshing = false;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

		public ObservableCollection<Article> ArticleList
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged(nameof(ArticleList));
            }
        }
        
        private void RefreshCommand()
        {
            IsRefreshing = true;
            ArticleList.Clear();

            Task.Factory.StartNew(async () =>
            {

				var news = await Fetch.FetchNewsFeed();
                await App.Database.StoreArticleAsync(news.ToList());

				OnPropertyChanged(nameof(ArticleList));
            });

			LoadArticles();
            IsRefreshing = false;
        }

		private async void LoadArticles()
		{
			var fromDb = await App.Database.GetArticlesAsync();
			ArticleList.Clear();
			fromDb.ForEach(a => ArticleList.Add(a));
			OnPropertyChanged(nameof(ArticleList));
		}


		//Constructor Loads Data on Application opening
		public LoadNewsViewModel()
		{
			PullToRefreshCommand = new Command(RefreshCommand);

			//RefreshCommand();

			LoadArticles();
		}


	               
        //Inherited 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
