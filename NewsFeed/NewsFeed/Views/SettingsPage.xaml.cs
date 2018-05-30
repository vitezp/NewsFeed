using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.API;
using NewsFeed.Models;
using NewsFeed.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsFeed.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage, ICategory
	{
	    public Category Category { get; set; }

        public SettingsPage ()
		{
			InitializeComponent ();
		    BindingContext = new SettingsViewModel();
		}

	    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var country = e.SelectedItem as Country;
	        ArticleFacade.Country = country;
	    }

    }
}