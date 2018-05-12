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
        private readonly SQLiteAsyncConnection _db;

        public DataService()
        {
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("NewsFeedSQLite.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Article>().Wait();
        }

        public async Task<News> GetItems()
        {
            var articles = await _db.Table<Article>().ToListAsync();
            var news = new News();
            news.Articles = articles;
            return news;
        }
    }
}
