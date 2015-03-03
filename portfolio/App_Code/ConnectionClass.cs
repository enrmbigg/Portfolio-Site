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

        public static ArrayList GetPostById(int idQuery)
        {
            ArrayList list;
            string query = string.Format("SELECT * FROM Posts WHERE id LIKE '{0}'", idQuery);
            ConnectionPost(query,out list);
            return list;
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

                    BlogPosts blog = new BlogPosts(id, title, body, image, date);
                    list.Add(blog);
                }
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public static void AddBlog(BlogPosts coffee)
        {
            string query = string.Format(
                @"INSERT INTO Posts (Title,Body,Image,Date) VALUES ('{0}', '{1}', '{2}', '{3}')",
                coffee.Title, coffee.Body, coffee.Image, coffee.Date); //DateTime.Today.ToString().Substring(0,11)
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

        public static ArrayList GetAllComments(int postId)
        {
            ArrayList list;
            string query = string.Format("SELECT * FROM Comments WHERE Comments.PostId = {0} ORDER BY Date DESC", postId);
            ConnectionComments(query, out list);
            return list;
        }
        public static ArrayList ConnectionComments(string query, out ArrayList list)
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

                    int CommentId = reader.GetInt32(0);
                    int PostId = reader.GetInt32(1);
                    string Author = reader.GetString(2);
                    string Email =  reader.GetString(3);
                    string Comment = reader.GetString(4);
                    string Date = reader.IsDBNull(5) ? "" : reader.GetString(4);

                    Comments cm = new Comments(CommentId,PostId,Author,Email,Comment,Date);
                    list.Add(cm);
                }
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

    }
}