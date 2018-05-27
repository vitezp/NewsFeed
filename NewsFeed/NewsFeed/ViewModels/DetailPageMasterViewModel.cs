using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using NewsFeed.Models;
using NewsFeed.Views;

namespace NewsFeed.ViewModels
{
    public class DetailPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DetailPageMenuItem> MenuItems { get; set; }

        public DetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<DetailPageMenuItem>(new[]
            {
                new DetailPageMenuItem {Id = 0, Category = "", Label = "All"},
                new DetailPageMenuItem {Id = 1, Category = "business", Label = "Business"},
                new DetailPageMenuItem {Id = 2, Category = "entertainment", Label = "Fun"},
                new DetailPageMenuItem {Id = 3, Category = "general", Label = "General"},
                new DetailPageMenuItem {Id = 4, Category = "health", Label = "Health"},
                new DetailPageMenuItem {Id = 5, Category = "science", Label = "Science"},
                new DetailPageMenuItem {Id = 6, Category = "sports", Label = "Sports"},
                new DetailPageMenuItem {Id = 7, Category = "technology", Label = "Technology"},
            });
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}