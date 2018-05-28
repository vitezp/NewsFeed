using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsFeed.Models;
using SQLite;

namespace NewsFeed.API
{
    public class ArticleDatabase
    {
		readonly SQLiteAsyncConnection database;
        

        public ArticleDatabase(string dbPath)
        {
			database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Article>();
        }
                
		public Task<List<Article>> GetArticlesAsync()
        {
			return database.QueryAsync<Article>("SELECT  * FROM Article " +
			                                    "WHERE Id IN(SELECT DISTINCT MIN(Id) FROM Article " +
			                                                "GROUP BY Description) " +
			                                    "ORDER BY PublishedDateTime DESC " +
			                                    "LIMIT 50");
			//return database.Table<Article>().OrderByDescending(mn=>mn.PublishedDateTime).ToListAsync();
        }
        
		public Task<List<Article>> GetArticlesByCategoryAsync(Category category)
        {
			if(category == Category.all) 
				return GetArticlesAsync();
			
			return database.Table<Article>().Where(mn=>mn.Category==category).OrderByDescending(mn => mn.PublishedDateTime).ToListAsync();
        }

		public Task<int> StoreArticleAsync(List<Article> art)
        {
			return StoreArticleAsync(art, Category.all);
        }

		public Task<int> StoreArticleAsync(List<Article> art, Category cat)
        {
            var latest = GetLatestArticle(cat);
            IEnumerable<Article> toUpdate = null;
            //picking items which are newer than latest article from DB and adding them into DB
            if (latest != null)
            {
				toUpdate = art.Where(mn => mn.PublishedDateTime > latest.PublishedDateTime && mn.Category == cat);
            }
            else
            {
                toUpdate = art;
            }
            return InsertArticleAsync(toUpdate.ToList());
        }


        public async Task<int> InsertArticleAsync(List<Article> articles)
		{
			return await database.InsertAllAsync(articles);
        }

		public Article GetLatestArticle()
        {
			return GetLatestArticle(Category.all);
        }

		public Article GetLatestArticle(Category category)
		{
			return database.Table<Article>().Where(mn=>mn.Category == category).OrderByDescending(m=>m.PublishedDateTime).FirstOrDefaultAsync().Result;
		}
    }
}
