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
                @"INSERT INTO picture VALUES ('{0}', '{1}', @price, '{2}', '{3}')",
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

    public static User LoginUser(string username, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM MilanovDB.dbo.users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the passwords match
                query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    query = string.Format("SELECT email, user_type FROM users WHERE username = '{0}'", username);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string type = reader.GetString(1);

                        user = new User(username, password, email, type);
                    }
                    return user;
                }
                else
                {
                    //Passwords do not match
                    return null;
                }
            }
            else
            {
                //User does not exist
                return null;
            }
        }
        finally
        {

            conn.Close();
        }
    }
    public static string RegisterUser(User user)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", user.Username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                //User does not exist, create a new user
                query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')", user.Username, user.Password,
                                      user.Email, user.Type);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "User registered!";
            }
            else
            {
                //User exists
                return "A user with this name already exists";
            }
        }
        finally
        {
            conn.Close();
        }
    }
}