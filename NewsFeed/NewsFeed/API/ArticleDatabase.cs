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
        
		public Task<Article> GetArticleAsync(DateTime id)
        {
			return database.Table<Article>().Where(mn => mn.PublishedDateTime.Equals(id)).FirstOrDefaultAsync();
        }


		public Task<int> StoreArticleAsync(List<Article> art)
		{
			var latest = GetLatestArticle();
			IEnumerable<Article> toUpdate = null;
			if (latest != null)
			{
				toUpdate = art.Where(mn => mn.PublishedDateTime > latest.PublishedDateTime);
			}else
			{
				toUpdate = art;
			}
			return InsertArticleAsync(toUpdate.ToList());           
		}

		public Task<int> InsertArticleAsync(List<Article> art)
        {

            //All articles will be Added, no update option

			return  database.InsertAllAsync(art);
        }

		public Task<int> UpdateArticleAsync(List<Article> art)
        {

            //All articles will be Added, no update option

            return database.UpdateAllAsync(art);
        }

		public Article GetLatestArticle()
		{
			return database.Table<Article>().OrderByDescending(m=>m.PublishedDateTime).FirstOrDefaultAsync().Result;
		}
    }
}
