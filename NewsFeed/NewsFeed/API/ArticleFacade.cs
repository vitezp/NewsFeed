using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;

namespace NewsFeed.API
{
    public static class ArticleFacade
    {
        private static string _category;

        public static async Task<List<Article>> GetArticles(string category)
        {
            var loadedArticles = await App.Database.GetArticlesAsync();

            if (loadedArticles.Count == 0 || _category != category)
            {
                loadedArticles = await Fetch.FetchNewsFeed(category);
                await App.Database.InsertArticleAsync(loadedArticles);
            }

            _category = category;

            return loadedArticles;
        }

        public static async Task<List<Article>> DoFetch()
        {
            var articles = await Fetch.FetchNewsFeed(_category);
            await App.Database.InsertArticleAsync(articles.ToList());
            return articles;
        }
    }
}
