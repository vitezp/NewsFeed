using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace NewsFeed.Models
{
    public enum Category
    {
            [Description("All")]
            All,
            [Description("Business")]
            Business,
            [Description("Fun")]
            Entertainment,
            [Description("General")]
            General,
            [Description("Health")]
            Health,
            [Description("Science")]
            Science,
            [Description("Sports")]
            Sports,
            [Description("Technology")]
            Technology,
    }
}

