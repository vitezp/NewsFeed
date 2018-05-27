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
			return database.Table<Article>().OrderByDescending(mn=>mn.PublishedDateTime).ToListAsync();
        }

		public async Task<int> InsertArticleAsync(List<Article> articles)
        {
            //All articles will be Added, no update option

            // clear table
            await database.DropTableAsync<Article>();
            await database.CreateTableAsync<Article>();
           
			return await database.InsertAllAsync(articles);
        }

		public Article GetLatestArticle()
		{
			return database.Table<Article>().OrderByDescending(m=>m.PublishedDateTime).FirstOrDefaultAsync().Result;
		}
    }
}
