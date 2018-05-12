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
        public static async Task FetchNewsFeed()
        {
            try
            {
                var client = new HttpClient();
                var response =
                    await client.GetAsync(
                        @"https://newsapi.org/v2/top-headlines?country=sk&apiKey=67d37685d7064a839ea635b1bde0b4f1");

                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                var msg = JsonConvert.DeserializeObject<News>(responseJson);
                Console.WriteLine(msg);
            }
            catch (Exception e)
            {
                // var msg = new ApiResponse();
            }

        } 
    }
}
