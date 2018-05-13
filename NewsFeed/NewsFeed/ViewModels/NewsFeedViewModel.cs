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

		public ICommand PullToRefreshCommand { get; private set; }

        public ObservableCollection<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        //Constructor Loads Data on Application opening
        public LoadNewsViewModel()
        {
            PullToRefreshCommand = new Command(RefreshCommand);
        }

        void RefreshCommand()
        {
			IsRefreshing = true;
            Articles.Clear();

            Task.Factory.StartNew(async () =>
            {
                var news = await NewsService.GetNews();
                news.Articles.ForEach(a => Articles.Add(a));
                OnPropertyChanged(nameof(Articles));
                IsRefreshing = false;
            });
			
		}

        //Inherited 
		public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
