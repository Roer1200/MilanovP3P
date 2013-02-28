using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;
     
    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MilanovDBConnectionString"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }

    public static ArrayList GetPictureByCategory(string pictureCategory)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM picture WHERE category LIKE '{0}'", pictureCategory);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string category = reader.GetString(2);
                double price = reader.GetDouble(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                Picture picture = new Picture(id, name, category, price, image, description);
                list.Add(picture);
            }
        }

        finally
        {
            conn.Close();
        }

        return list;
    }

    public static void AddPicture(Picture picture)
    {
        string query = string.Format(
                @"INSERT INTO picture VALUES ('{0}', '{1}', @prices, '{2}', '{3}')",
                picture.Name, picture.Category, picture.Image, picture.Description);
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@price", picture.Price));
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