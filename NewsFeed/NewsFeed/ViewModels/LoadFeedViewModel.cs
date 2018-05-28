﻿using System;
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
		private Category _category;

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


		//Constructor Loads Data on Application opening
		public LoadNewsViewModel(Category category)
		{
			PullToRefreshCommand = new Command(RefreshCommand);
			_category = category;
			LoadArticles();
		}

		private void RefreshCommand()
		{
			IsRefreshing = true;
			ArticleList.Clear();

			Task.Factory.StartNew(async () =>
			{
				var articles = await ArticleFacade.FetchArticles();

				articles.ForEach(a => ArticleList.Add(a));
				OnPropertyChanged(nameof(ArticleList));
			});
			IsRefreshing = false;
		}

		private async void LoadArticles()
		{
			var fromDb = await ArticleFacade.GetArticles(_category);
			ArticleList.Clear();
			if (!fromDb.Any())
			{
				fromDb = await ArticleFacade.FetchArticles(_category);
			}
			fromDb.ForEach(a => ArticleList.Add(a));
			OnPropertyChanged(nameof(ArticleList));
		}


		//Inherited 
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}



	}
}
