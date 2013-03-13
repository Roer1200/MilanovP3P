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

    public static ArrayList GetProductByCategory(int productCategory)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM products WHERE cat_id LIKE '{0}'", productCategory);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int cat_id = reader.GetInt32(2);
                double price = reader.GetDouble(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                Products product = new Products(id, name, cat_id, price, image, description);
                list.Add(product);
            }
        }

        finally
        {
            conn.Close();
        }

        return list;
    }

    #region Add *
    public static void AddCategory(Categories category)
    {
        string query = string.Format(
                @"INSERT INTO categories VALUES ('{0}')",
                category.Name);
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

    public static void AddProduct(Products product)
    {
        string query = string.Format(
                @"INSERT INTO products VALUES ('{0}', '{1}', @price, '{2}', '{3}')",
                product.Name, product.Cat_id, product.Image, product.Description);
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@price", product.Price));
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

    public static void AddRole(Roles role)
    {
        string query = string.Format(
                @"INSERT INTO roles VALUES ('{0}')",
                role.Name);
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
    #endregion

    public static Users LoginUser(string username, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", username);
        // string query = string.Format("SELECT COUNT(*) FROM MilanovDB.dbo.users WHERE username = '{0}'", username);
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
                    query = string.Format("SELECT email, rol_id FROM users WHERE username = '{0}'", username);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    Users users = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        int rol_id = reader.GetInt32(1);

                        users = new Users(username, password, email, rol_id);
                    }
                    return users;
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


    public static string RegisterUser(Users users)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", users.Username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                //User does not exist, create a new user
                query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')", users.Username, users.Password,
                                      users.Email, users.Rol_id);
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