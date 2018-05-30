using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using NewsFeed.Annotations;
using NewsFeed.Models;

namespace NewsFeed.ViewModels
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Country> MenuItems { get; set; }

        public SettingsViewModel()
        {
            MenuItems = new ObservableCollection<Country>
            {
                new Country("sk", "Slovakia"),
                new Country("cz", "Czechia"),
            };
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
