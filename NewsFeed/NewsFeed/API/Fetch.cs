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
		public static async Task<List<Article>> FetchNewsFeed(string category = "")
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(BuildUrl(category));

                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                var news = JsonConvert.DeserializeObject<News>(responseJson);

                int id = 0;

				foreach(var article in news.Articles)
				{
				    article.Id = id;
					article.PublishedDateTime = Convert.ToDateTime(article.PublishedAt);
					article.PrintableDateTime = GetDateTime(article.PublishedDateTime);
				    id++;
				}
				Console.WriteLine(news.Articles.Count);

				return news.Articles;
            }
            catch (Exception e)
            {
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

        private static string BuildUrl(string category)
        {
            var attach = string.IsNullOrEmpty(category) ? "" : $"&category={category}";
            return @"https://newsapi.org/v2/top-headlines?country=sk&apiKey=67d37685d7064a839ea635b1bde0b4f1" + attach;
        }

    }
}
