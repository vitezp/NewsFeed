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
				new DetailPageMenuItem {Id = 0, Category = Category.all, Label = "All"},
				new DetailPageMenuItem {Id = 1, Category = Category.business, Label = EnumExtensions.GetDescription(Category.business)},
				new DetailPageMenuItem {Id = 2, Category = Category.entertainment, Label = EnumExtensions.GetDescription(Category.entertainment)},
				new DetailPageMenuItem {Id = 3, Category = Category.general, Label = EnumExtensions.GetDescription(Category.general)},
				new DetailPageMenuItem {Id = 4, Category = Category.health, Label = EnumExtensions.GetDescription(Category.health)},
				new DetailPageMenuItem {Id = 5, Category = Category.science, Label = EnumExtensions.GetDescription(Category.science)},
				new DetailPageMenuItem {Id = 6, Category = Category.sports, Label = EnumExtensions.GetDescription(Category.sports)},
				new DetailPageMenuItem {Id = 7, Category = Category.science, Label = EnumExtensions.GetDescription(Category.technology)}
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