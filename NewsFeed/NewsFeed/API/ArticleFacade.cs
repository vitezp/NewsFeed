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
        private static Category _category;

		public static async Task<List<Article>> GetArticles(Category category)
        {
            var loadedArticles = await App.Database.GetArticlesAsync();

            if (loadedArticles.Count == 0 || _category != category)
            {
				loadedArticles = await DoFetch(category);
            }

            _category = category;

            return loadedArticles;
        }


		public static async Task<List<Article>> DoFetch()
        {
            return await DoFetch(_category);
        }

		public static async Task<List<Article>> DoFetch(Category cat)
        {
            var articles = await Fetch.FetchNewsFeed(cat);
            await App.Database.InsertArticleAsync(articles.ToList());
            return articles;
        }


    }
}
