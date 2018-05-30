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
		public static async Task<List<Article>> FetchNewsFeed(Category category, Country country)
        {
            try
            {
                var client = new HttpClient();
                var url = BuildUrl(category, country);
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                var news = JsonConvert.DeserializeObject<News>(responseJson);


				foreach(var article in news.Articles)
				{
					article.PublishedDateTime = Convert.ToDateTime(article.PublishedAt);
					article.PrintableDateTime = GetDateTime(article.PublishedDateTime);
					article.Category = category;
					Console.WriteLine("Category : {0}", article.Category);
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

        //performed only once, while loaded
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

		private static string BuildUrl(Category category, Country country)
		{
            var url = new StringBuilder();
		    url.Append("https://newsapi.org/v2/top-headlines?apiKey=67d37685d7064a839ea635b1bde0b4f1");
		    url.Append($"&country={country.Code}");
			url.Append(category.Equals(Category.All) ? "" : $"&category={category}");
		    return url.ToString();
		}

    }
}
