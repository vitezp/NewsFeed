﻿using System.Threading.Tasks;
using NewsFeed.API;
using Xamarin.Forms;

namespace NewsFeed
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NewsFeedPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Task.Factory.StartNew( Fetch.FetchNewsFeed );
        }
    }
}
