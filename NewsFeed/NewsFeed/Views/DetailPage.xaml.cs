using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsFeed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : MasterDetailPage
    {
        public DetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as DetailPageMenuItem;
            if (item == null)
                return;

            var page = (ContentPage) Activator.CreateInstance(item.TargetType);
            page.Category = item.Category;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}