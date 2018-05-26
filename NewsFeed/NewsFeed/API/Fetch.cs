using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;
using Newtonsoft.Json;


namespace NewsFeed.API
{
    public static class Fetch
    {
		public static async Task<List<Article>> FetchNewsFeed()
        {
            try
            {
                var client = new HttpClient();
                var response =
                    await client.GetAsync(
                        @"https://newsapi.org/v2/top-headlines?country=sk&apiKey=67d37685d7064a839ea635b1bde0b4f1");

                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                var news = JsonConvert.DeserializeObject<News>(responseJson);

				foreach(var art in news.Articles)
				{
					art.PublishedDateTime = Convert.ToDateTime(art.PublishedAt);
					art.PrintableDateTime = GetDateTime(art.PublishedDateTime);
				}
				Console.WriteLine(news.Articles.Count);

				return news.Articles;
            }
            catch (Exception e)
            {
                // var msg = new ApiResponse();
                Console.WriteLine(e.Message);
				return new List<Article>();
            }
        } 

		private static string GetDateTime(DateTime dateTime)
        {
            //converting to dateTime
            var sb = new StringBuilder();

            if (dateTime.Day < DateTime.Now.Day)
            {
                sb.Append($"{dateTime:dd.MM} ");
            }
            sb.Append($"{dateTime:HH:mm}");
            return sb.ToString();
        }

    }
}
