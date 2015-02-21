using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlServerCe;

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
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM Posts WHERE id LIKE '{0}'", idQuery.ToString());
        Connection(query,out list);
        return list;
    }
    public static ArrayList GetAll()
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM Posts ORDER BY Date DESC");
        Connection(query, out list);
        return list;
    }
    public static ArrayList Connection(string query, out ArrayList list )
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
            coffee.title, coffee.body, coffee.image, coffee.date); //DateTime.Today.ToString().Substring(0,11)
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

}