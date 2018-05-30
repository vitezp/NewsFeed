using System;
using System.Collections.Generic;
using System.Text;
using NewsFeed.Models;
using Xamarin.Forms;

namespace NewsFeed.Utils
{
    public static class Settings
    {
        public static Country Country
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("country"))
                {
                    return Application.Current.Properties["country"] as Country;
                }

                var country = new Country("sk", "Slovakia");
                Application.Current.Properties.Add("country", country);
                return country;
            }
            set
            {
                Application.Current.Properties["country"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
    }
}
