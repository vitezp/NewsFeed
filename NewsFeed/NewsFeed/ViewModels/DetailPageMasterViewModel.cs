using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using NewsFeed.Models;
using NewsFeed.Views;
using static NewsFeed.Models.EnumExtensions;

namespace NewsFeed.ViewModels
{
	public class DetailPageMasterViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<DetailPageMenuItem> MenuItems { get; set; }

        public DetailPageMasterViewModel()
        {
            var items = new List<DetailPageMenuItem>();
            var i = 0;

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                items.Add( new DetailPageMenuItem
                {
                    Category = category,
                    Label = category.GetDescription(),
                    Id = i++,
                });
            }

            // Settings special case
            items.First(c => c.Category == Category.Settings).TargetType = typeof(SettingsPage);

			MenuItems = new ObservableCollection<DetailPageMenuItem>(items);
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