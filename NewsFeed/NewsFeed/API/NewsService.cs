using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;

namespace NewsFeed.API
{
    public static class NewsService
    {
		/*
        public static async Task<News> GetNews()
        {
            int timeout = 3000; // 3s
            // try fetch, if fail check offline db
            var fetch = Fetch.FetchNewsFeed();
            Console.WriteLine("Get News");
            if (await Task.WhenAny(fetch, Task.Delay(timeout)) == fetch)
            {
                // fetch completed within timeout
                var news = await fetch;
                var result = await DataService.SaveItemAsync(news);
                Console.WriteLine("Writing to DataService: " + result);
                return news;
            }
            else
            {
                Console.WriteLine("Going Offline");
                // check in offline db
                var items = await DataService.GetItems();
                return null;
            }
        }*/
    }
}
