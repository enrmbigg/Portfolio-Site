using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace portfolio.App_Code
{
    class Blog
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string image { get; set; }
        public DateTime date { get; set; }

        public Blog( int id, string title, string body, string image, DateTime Date)
        {
            this.id = id;
            this.title = title;
            this.body = body;
            this.image = image;
            this.date = date;
        }


    }
}
