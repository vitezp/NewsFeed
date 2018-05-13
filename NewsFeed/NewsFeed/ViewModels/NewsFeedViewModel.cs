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

        public ICommand PullToRefreshCommand { get; private set; }
        public ICommand ItemClicked { get; private set; }

        private bool _isRefreshing = false;
        private Article _selectedItem;


        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

		public ObservableCollection<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }


        public Article SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                    return;

                ItemClicked.Execute(_selectedItem);

                SelectedItem = null;
            }
        }

        private void RefreshCommand()
        {
            IsRefreshing = true;
            Articles.Clear();

            Task.Factory.StartNew(async () =>
            {
                var news = await NewsService.GetNews();
                news.Articles.ForEach(a => Articles.Add(a));
                OnPropertyChanged(nameof(Articles));
            });
            IsRefreshing = false;
        }

        private void ItemClickedCommand()
        {
            Device.OpenUri(new Uri(_selectedItem.Url));
        }

        //Constructor Loads Data on Application opening
        public LoadNewsViewModel()
        {
            PullToRefreshCommand = new Command(RefreshCommand);
            ItemClicked = new Command(ItemClickedCommand);

            RefreshCommand();
        }

                
        //Inherited 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
