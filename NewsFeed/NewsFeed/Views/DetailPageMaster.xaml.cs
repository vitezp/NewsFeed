using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        class DetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DetailPageMenuItem> MenuItems { get; set; }
            
            public DetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DetailPageMenuItem>(new[]
                {
                    new DetailPageMenuItem { Id = 0, Title = "Page 1" },
                    new DetailPageMenuItem { Id = 1, Title = "Page 2" },
                    new DetailPageMenuItem { Id = 2, Title = "Page 3" },
                    new DetailPageMenuItem { Id = 3, Title = "Page 4" },
                    new DetailPageMenuItem { Id = 4, Title = "Page 5" },
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
}