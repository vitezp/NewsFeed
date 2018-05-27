using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace NewsFeed.Models
{
    public enum Category
    {
            [Description("Business")]
            business,
            [Description("Fun")]
            entertainment,
            [Description("General")]
            general,
            [Description("Health")]
            health,
            [Description("Science")]
            science,
            [Description("Sports")]
            sports,
            [Description("Technology")]
            technology,
		    [Description("All")]
            all
    }
}

