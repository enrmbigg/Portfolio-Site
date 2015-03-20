using System.Collections;
using System.Configuration;
using System.Data.SqlServerCe;

namespace portfolio
{
    public static class ConnectionClass
    {
        private static SqlCeConnection conn;
        private static SqlCeCommand command;

        static ConnectionClass()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BlogPosts"].ConnectionString;
            conn = new SqlCeConnection(connectionString);
            command = new SqlCeCommand("", conn);
        }

        public static BlogPosts GetPostById(int idQuery)
        {
            ArrayList list;
            string query = string.Format("SELECT * FROM Posts WHERE id LIKE '{0}'", idQuery);
            ConnectionPost(query,out list);
            var post = (BlogPosts)list[0];
            return post;
        }
        public static ArrayList GetAllPosts()
        {
            ArrayList list;
            string query = string.Format("SELECT * FROM Posts ORDER BY Date DESC");
            ConnectionPost(query, out list);
            return list;
        }

        public static ArrayList ConnectionPost(string query, out ArrayList list)
        {
            list = new ArrayList();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BlogPosts"].ConnectionString;
                conn = new SqlCeConnection(connectionString);
                command = new SqlCeCommand("", conn);
                conn.Open();
                command.CommandText = query;
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string body = reader.GetString(2);
                    string image = reader.GetString(3);
                    string date = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    string tag = reader.IsDBNull(5) ? "" : reader.GetString(5);

                    BlogPosts blog = new BlogPosts(id, title, body, image, date, tag);
                    list.Add(blog);
                }
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public static void AddBlog(BlogPosts post)
        {
            string query = string.Format(
                @"INSERT INTO Posts (Title,Body,Image,Date,Tag) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                post.Title, post.Body, post.Image, post.Date, post.Tag);
            command.CommandText = query;
        
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                command.Parameters.Clear();
            }
        }

        public static BlogPosts GetPostByTitle(string titleQuery, string order)
        {
            ArrayList list;
            string query = string.Format("SELECT * FROM Posts WHERE Title LIKE '{0}' ORDER BY Date {1}", titleQuery, order);
            ConnectionPost(query, out list);
            var post = (BlogPosts)list[0];
            return post;
        }
    }
}