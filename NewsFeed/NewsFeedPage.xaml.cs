using System;
using System.Collections;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsFeed
{
	public partial class NewsFeedPage : MasterDetailPage
    {


		public NewsFeedPage()
        {
            InitializeComponent();


			listView.SelectedItem = (listView.ItemsSource as IList)?[0];

			MainPage = new NavigationPage();
            

        }

        public NavigationPage MainPage { get; private set; }

        private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
			IsPresented = false;

        }

    }
}
