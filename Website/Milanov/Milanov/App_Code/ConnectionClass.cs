using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

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

    public static ArrayList GetProductByCategory(string productCategory)
    {
        ArrayList list = new ArrayList();
        // string query = string.Format("SELECT * FROM products WHERE cat_id LIKE '{0}'", productCategory);
        string query = string.Format("SELECT p.id, p.name, c.name AS cname, p.price, p.image, p.description FROM products AS p INNER JOIN categories AS c ON p.cat_id = c.id WHERE p.cat_id LIKE '{0}'", productCategory);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                //int cat_id = reader.GetInt32(2);
                string cname = reader.GetString(2);
                decimal price = reader.GetDecimal(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                //Products product = new Products(id, name, cat_id, price, image, description);
                Products product = new Products(id, name, cname, price, image, description);
                list.Add(product);
            }
        }

        finally
        {
            conn.Close();
        }

        return list;
    }
    
    public static ArrayList GetProductDetails(string productId)
    {
        ArrayList list = new ArrayList();
        //string query = string.Format("SELECT * FROM products WHERE id LIKE '{0}'", productId);
        string query = string.Format("SELECT p.id, p.name, c.name AS cname, p.price, p.image, p.description FROM products AS p INNER JOIN categories AS c ON p.cat_id = c.id WHERE p.id LIKE '{0}'", productId);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                // int cat_id = reader.GetInt32(2);
                string cname = reader.GetString(2);
                decimal price = reader.GetDecimal(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                //Products product = new Products(id, name, cat_id, price, image, description);
                Products product = new Products(id, name, cname, price, image, description);
                list.Add(product);
            }
        }

        finally
        {
            conn.Close();
        }

        return list;
    }

    public static ArrayList GetShopProducts(List<string> productId)
    {
        ArrayList list = new ArrayList();

        foreach (string p in productId)
        {
            string query = string.Format("SELECT * FROM products WHERE id LIKE '{0}'", p);

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
                    decimal price = reader.GetDecimal(3);
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
        }

        return list;
    }

    public static string AddCategory(Categories category)
    {
        // Check if category exists
        string query = string.Format("SELECT COUNT(*) FROM categories WHERE name = '{0}'", category.Name);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfCategorys = (int)command.ExecuteScalar();

            if (amountOfCategorys < 1)
            {
                // Category does not exists, create a new category
                query = string.Format(@"INSERT INTO categories VALUES ('{0}')", category.Name);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "Categorie toegevoegd!";
            }
            else
            {
                // Category exists
                return "Deze categorie bestaat al, categorie niet toegevoegd.";
            }            
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    } // Klaar

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
                //User does not exist, check  if e-mail exists
                query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", users.Email);
                command.CommandText = query;

                int amountOfEmail = (int)command.ExecuteScalar();

                if (amountOfEmail < 1)
                {
                    query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')", users.Username, users.Password,
                                          users.Email, users.Rol_id);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    return "Uw account (" + users.Username + ") is aangemaakt!";
                }
                else
                {
                    // E-mail exists
                    return "Een gebruiker met dit e-mail adres bestaat al, het account is niet aangemaakt.";
                }
            }
            else
            {
                //User exists
                return "Een gebruiker met deze gebruikersnaam bestaat al, het account is niet aangemaakt.";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    } // Klaar

    public static string ForgotPassword(string username, string email)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the emails match
                query = string.Format("SELECT email FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                string dbEmail = command.ExecuteScalar().ToString();

                if (dbEmail == email)
                {
                    //Username and email matches
                    query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
                    command.CommandText = query;
                    string password = command.ExecuteScalar().ToString();
                    return password;
                }
                else
                {
                    //Email does not match username
                    return "Wachtwoord is niet verzonden, e-mail komt niet overeen met de gebruikersnaam.";
                }
            }
            else
            {
                //User does not exist
                return "Wachtwoord is niet verzonden, gebruiker bestaat niet.";
            }
        }
        finally
        {
            conn.Close();
        }
    }

    public static string ChangePassword(string username, string Pcurrent, string Pnew)
    {
        string query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            string dbPassword = command.ExecuteScalar().ToString();

            if (dbPassword == Pcurrent)
            {
                // Passwords match
                query = string.Format("UPDATE users SET password = '{0}' WHERE username = '{1}'", Pnew, username);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "Het wachtwoord is aangepast, de volgende keer dat u inlogt moet u gebruik maken van dit nieuwe wachtwoord.";
            }
            else
            {
                // Passwords do not match
                return "Het huidige wachtwoord komt niet overeen.";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    } // Klaar

    public static string ChangeEmail(string username, string Ecurrent, string Enew)
    {
        string query = string.Format("SELECT email FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            string dbEmail = command.ExecuteScalar().ToString();

            if (dbEmail == Ecurrent)
            {
                // Emails match, check if new e-mail is in use
                query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", Enew);
                command.CommandText = query;

                int amountOfEmail = (int)command.ExecuteScalar();

                if (amountOfEmail < 1)
                {
                    query = string.Format("UPDATE users SET email = '{0}' WHERE username = '{1}'", Enew, username);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    return "Uw mail adres is aangepast!";
                }
                else
                {
                    return "Het nieuwe e-mail adres is al in gebruik!";
                }
            }
            else
            {
                // Emails do not match
                return "De huidige e-mail komt niet overeen!";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static string GetEmail(string username)
    {
        string query = string.Format("SELECT email FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            string dbEmail = command.ExecuteScalar().ToString();
            return dbEmail;
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    } // Klaar

    public static string GetRole(string username)
    {
        string query = string.Format("SELECT r.name FROM users AS u INNER JOIN roles AS r ON u.rol_id = r.id WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            string dbRole = command.ExecuteScalar().ToString();
            return dbRole;
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    } // Klaar    

    public static ArrayList ShoppingItem(string productId)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM products WHERE id LIKE '{0}'", productId);

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
                decimal price = reader.GetDecimal(3);
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

    public static bool GetInUseCategories(string categoryId)
    {
        // Check if category is in use
        string query = string.Format("SELECT COUNT(*) FROM products WHERE cat_id = '{0}'", categoryId);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfCategorys = (int)command.ExecuteScalar();

            if (amountOfCategorys > 0)
            {
                // Category in use
                return true;
            }
            else
            {
                // Category not in use
                return false;
            }            
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    } // Klaar
}