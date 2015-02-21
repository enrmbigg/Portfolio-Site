
    public class BlogPosts
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string image { get; set; }
        public string date { get; set; }

        public BlogPosts( int id, string title, string body, string image, string date)
        {
            this.id = id;
            this.title = title;
            this.body = body;
            this.image = image;
            this.date = date;
        }

        public BlogPosts(string title, string body, string image, string date)
        {
            this.title = title;
            this.body = body;
            this.image = image;
            this.date = date;
        }


    }
