using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeed.Models
{
    public class Country
    {
        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }
        public string Code { get; }
        public string Name { get; }

        public override string ToString() => $"{Code} - {Name}";

    }
}
