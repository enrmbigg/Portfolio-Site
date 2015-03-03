    namespace portfolio
    {
        public class Comments
        {
            public int CommentId { get; set; }
            public int PostId { get; set; }
            public string Author { get; set; }
            public string Email { get; set; }
            public string Comment { get; set; }
            public string Date { get; set; }

            public Comments(int cId, int pId, string a, string e, string c, string d)
            {
                CommentId = cId;
                PostId = pId;
                Author = a;
                Email = e;
                Comment = c;
                Date = d;
            }
        }
    }
