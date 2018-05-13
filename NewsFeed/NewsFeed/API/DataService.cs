using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Models;
using SQLite;
using Xamarin.Forms;

namespace NewsFeed.API
{
    public class DataService
    {
        private static SQLiteAsyncConnection _db;

        private static SQLiteAsyncConnection Database
        {
            get
            {
                if (_db == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var dbPath = fileHelper.GetLocalFilePath("NewsFeedSQLite2.db3");
                    Console.WriteLine("Opening DB at: " + dbPath);
                    var db = new SQLiteAsyncConnection(dbPath);
                    db.CreateTableAsync<Article>().Wait();
                    _db = db;
                }

                return _db;
            }
        }

        


        public static async Task<News> GetItems()
        {
            var articles = await Database.Table<Article>().ToListAsync();
            var news = new News
            {
                Articles = articles
            };
            return news;
        }

        public static Task<int> SaveItemAsync(News news)
        {
            Console.WriteLine("SaveItemAsync");
            return Database.InsertAllAsync(news.Articles);
        }
    }
}
