using System;
using System.Collections.Generic;
using System.Text;
using NewsFeed.Models;

namespace NewsFeed.Views
{
    public interface ICategory
    {
        Category Category { get; set; }
    }
}
