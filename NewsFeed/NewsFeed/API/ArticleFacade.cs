using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;
using NewsFeed.Utils;

namespace NewsFeed.API
{
    public static class ArticleFacade
    {
        private static Category _category;
        public static Country Country { get; set; } = Settings.Country;

        public static async Task<List<Article>> GetArticles()
        {
			return await GetArticles(_category);
        }

		public static async Task<List<Article>> GetArticles(Category category)
        {
			_category = category;
            var articles = await Fetch.FetchNewsFeed(category, Country);
            if (!articles.Any())
            {
                return await App.Database.GetArticlesByCategoryAsync(category);
            }

            await App.Database.StoreArticleAsync(articles.ToList(), category);
            return articles;
        }
    }
}
