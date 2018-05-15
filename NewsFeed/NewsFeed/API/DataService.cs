using System;
using System.Collections.Generic;
using System.IO;
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
                    var sqliteFilename = "MyDatabase.db3";
                    #if __IOS__
                        // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                        // (they don't want non-user-generated data in Documents)
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                        string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead
                    #else
                        // Just use whatever directory SpecialFolder.Personal returns
                        string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    #endif
                    var path = Path.Combine(libraryPath, sqliteFilename);
                    Console.WriteLine("Opening DB at: " + path);
                    var db = new SQLiteAsyncConnection(path);
                    db.CreateTableAsync<Article>().Wait();
                    
                    _db = db;
                }

                return _db;
            }
        }


        public static void ForceInit()
        {
            Console.WriteLine("\nForceInit\n");
            var db = Database;
        }

        public static async Task<News> GetItems()
        {
            var articles = new List<Article>();
            try
            {
                // articles = await Database.Table<Article>().ToListAsync();
            }
            catch
            {
                Console.WriteLine("Offline articles unsuccessful");
            }
    
            return new News
            {
                Articles = articles
            };
        }

        public static Task<int> SaveItemAsync(News news)
        {
            Console.WriteLine("SaveItemAsync");
            return Database.InsertAllAsync(news.Articles);
        }
        /*
		public static int SaveItemAsync()
        {
            Console.WriteLine("SaveItem");
            return Database.InsertAllAsync(news.Articles);
        }*/
    }
}
