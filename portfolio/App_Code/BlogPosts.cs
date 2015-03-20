    namespace portfolio
    {
        public class BlogPosts
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string Image { get; set; }
            public string Date { get; set; }
            public string Tag { get; set; }

            public BlogPosts( int id, string title, string body, string image, string date, string tag)
            {
                Id = id;
                Title = title;
                Body = body;
                Image = image;
                Date = date;
                Tag = tag;
            }

            public BlogPosts(string title, string body, string image, string date, string tag)
            {
                Title = title;
                Body = body;
                Image = image;
                Date = date;
                Tag = tag;
            }


        }
    }
