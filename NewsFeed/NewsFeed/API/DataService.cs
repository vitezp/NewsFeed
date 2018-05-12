using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;
using SQLite;
using Xamarin.Forms;

namespace NewsFeed.API
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }

    public class DataService
    {
        private static SQLiteAsyncConnection _db
        {
            get
            {
                var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("NewsFeedSQLite.db3");
                var db = new SQLiteAsyncConnection(dbPath);
                db.CreateTableAsync<Article>().Wait();
                return db;
            }
        }


        public static async Task<News> GetItems()
        {
            var articles = await _db.Table<Article>().ToListAsync();
            var news = new News
            {
                Articles = articles
            };
            return news;
        }

        public static Task<int> SaveItemAsync(News news)
        {
            var articles = news.Articles;
            // delete all first
            return _db.InsertAsync(news);
        }
    }
}
