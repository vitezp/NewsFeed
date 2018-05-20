﻿using System;
using System.IO;
using NewsFeed.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace NewsFeed.Android
{
    public class FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string filename)
        {
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
