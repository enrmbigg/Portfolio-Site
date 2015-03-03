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

            public BlogPosts( int id, string title, string body, string image, string date)
            {
                Id = id;
                Title = title;
                Body = body;
                Image = image;
                Date = date;
            }

            public BlogPosts(string title, string body, string image, string date)
            {
                Title = title;
                Body = body;
                Image = image;
                Date = date;
            }


        }
    }
