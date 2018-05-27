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

		public static async Task<List<Article>> GetArticles()
        {
			return await GetArticles(_category);
        }

		public static async Task<List<Article>> GetArticles(Category category)
        {
			_category = category;
            var loadedArticles = await App.Database.GetArticlesByCategoryAsync(category);   

            return loadedArticles;
        }


		public static async Task<List<Article>> DoFetch()
        {
            return await DoFetch(_category);
        }

		public static async Task<List<Article>> DoFetch(Category cat)
        {
			_category = cat;
			var articles = await Fetch.FetchNewsFeed(cat);
			await App.Database.StoreArticleAsync(articles.ToList(), cat);
			return await App.Database.GetArticlesByCategoryAsync(cat);
        }


    }
}
