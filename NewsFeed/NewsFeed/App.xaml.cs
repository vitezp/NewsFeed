using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.API;
using NewsFeed.Views;
using Xamarin.Forms;

namespace NewsFeed
{
	public partial class App : Application
	{
		static ArticleDatabase database;

		public App ()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new MainPage());
		    MainPage = new DetailPage();
		}

		public static ArticleDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ArticleDatabase(
						DependencyService.Get<IFileHelper>()
						.GetLocalFilePath("Article.db3"));
                }
                return database;
            }
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
