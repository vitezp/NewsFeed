using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsFeed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageMaster : ContentPage
    {
        public ListView ListView;

        public DetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new DetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }
    }
}