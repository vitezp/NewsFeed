using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.API;
using Xamarin.Forms;

namespace NewsFeed
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    // Init DB
            DataService.ForceInit();

            MainPage = new NewsFeed.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
            //This should save data into database so they are available after starting app without access to internet
			// Handle when your app sleeps

			//var result = DataService.SaveItemAsync();

		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
