using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using NewsFeed.Models;
using static NewsFeed.Models.EnumExtensions;

namespace NewsFeed.ViewModels
{
	public class DetailPageMasterViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<DetailPageMenuItem> MenuItems { get; set; }

        public DetailPageMasterViewModel()
		{
			MenuItems = new ObservableCollection<DetailPageMenuItem>(new[]
			{
				new DetailPageMenuItem {Id = 0, Category = Category.All, Label = Category.All.GetDescription()},
				new DetailPageMenuItem {Id = 1, Category = Category.Business, Label = Category.Business.GetDescription()},
				new DetailPageMenuItem {Id = 2, Category = Category.Entertainment, Label = Category.Entertainment.GetDescription()},
				new DetailPageMenuItem {Id = 3, Category = Category.General, Label = Category.General.GetDescription()},
				new DetailPageMenuItem {Id = 4, Category = Category.Health, Label = Category.Health.GetDescription()},
				new DetailPageMenuItem {Id = 5, Category = Category.Science, Label = Category.Science.GetDescription()},
				new DetailPageMenuItem {Id = 6, Category = Category.Sports, Label = Category.Sports.GetDescription()},
				new DetailPageMenuItem {Id = 7, Category = Category.Science, Label = Category.Technology.GetDescription()}
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