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

    #region GetProductByCategory
    /// <summary>
    /// Returns all the products in the specified category
    /// </summary>
    /// <param name="productCategory"></param>
    /// <returns></returns>
    public static ArrayList GetProductByCategory(string productCategory)
    {
        ArrayList list = new ArrayList();
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
                string cname = reader.GetString(2);
                decimal price = reader.GetDecimal(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                Products product = new Products(id, name, cname, price, image, description);
                list.Add(product);
            }
        }

        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return list;
    }
    #endregion

    #region GetProductDetails
    /// <summary>
    /// Returns all the product details of the specified product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public static ArrayList GetProductDetails(string productId)
    {
        ArrayList list = new ArrayList();
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
                string cname = reader.GetString(2);
                decimal price = reader.GetDecimal(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                Products product = new Products(id, name, cname, price, image, description);
                list.Add(product);
            }
        }

        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return list;
    }
    #endregion

    #region GetShopProducts
    /// <summary>
    /// Returns all the products that are added to shoppingcart
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
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
                command.Parameters.Clear();
            }
        }

        return list;
    }
    #endregion

    #region GetInUseCategories
    /// <summary>
    /// Checks if a category is in use by a product and returns a bool (true or false)
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public static bool GetInUseCategories(string categoryId)
    {        
        string query = string.Format("SELECT COUNT(*) FROM products WHERE cat_id = '{0}'", categoryId);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfCategorys = (int)command.ExecuteScalar();

            if (amountOfCategorys > 0) // Check if category is in use
            {
                // Category in use
                return true;
            }
            else
            {
                // Category NOT in use
                return false;
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    #endregion

    #region GetEmail
    /// <summary>
    /// Searches the e-mail in database that matches to the logged in user and returns this e-mail
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
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
    }
    #endregion

    #region GetRole
    /// <summary>
    /// Searches the role in database that matches to the logged in user and returns this role
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
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
    }
    #endregion

    #region AddCategory
    /// <summary>
    /// AddCategory checks if the category name is not in use, if not in use it adds a new category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    public static string AddCategory(Categories category)
    {
        string query = string.Format("SELECT COUNT(*) FROM categories WHERE name = '{0}'", category.Name);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfCategorys = (int)command.ExecuteScalar();

            if (amountOfCategorys < 1)      // Check if category does NOT exist
            {
                // Category does NOT exists, create a new category
                query = string.Format(@"INSERT INTO categories VALUES ('{0}')", category.Name);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "Categorie toegevoegd!";
            }
            else        // Category exists, return error message
            {
                return "Deze categorie bestaat al, categorie niet toegevoegd.";
            }            
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    #endregion

    #region AddProduct
    /// <summary>
    /// AddProduct adds a new product
    /// </summary>
    /// <param name="product"></param>
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
    #endregion

    #region LoginUser
    /// <summary>
    /// LoginUser checks if the login credentials are correct
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static Users LoginUser(string username, string password)
    {
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)         // Check if user exists
            {
                // User exists
                query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)     // Check if the passwords match
                {
                    // Passwords match. Login and password data are known to us
                    // Retrieve further user data from the database
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
            command.Parameters.Clear();
        }
    }
    #endregion

    #region RegisterUser
    /// <summary>
    /// RegisterUser checks if the username and e-mail are unique, if so it adds the new user into database, otherwise it returns a error message
    /// </summary>
    /// <param name="users"></param>
    /// <returns></returns>
    public static string RegisterUser(Users users)
    {        
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", users.Username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)      // Check if user exists
            {
                // User does NOT exist
                query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", users.Email);
                command.CommandText = query;

                int amountOfEmail = (int)command.ExecuteScalar();

                if (amountOfEmail < 1)      // Check if e-mail exists
                {
                    // E-mail does NOT exist
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
                // User exists
                return "Een gebruiker met deze gebruikersnaam bestaat al, het account is niet aangemaakt.";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    #endregion

    #region ForgotPassword
    /// <summary>
    /// Checks if the username and e-mail match, if so it returns the password, otherwise it returns a error message
    /// </summary>
    /// <param name="username"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public static string ForgotPassword(string username, string email)
    {
        string query = string.Format("SELECT COUNT(*) FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)     // Check if user exists
            {
                //User exists
                query = string.Format("SELECT email FROM users WHERE username = '{0}'", username);
                command.CommandText = query;
                string dbEmail = command.ExecuteScalar().ToString();

                if (dbEmail == email)       // Check if the e-mails match
                {
                    // Username and e-mail matches
                    query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
                    command.CommandText = query;
                    string password = command.ExecuteScalar().ToString();
                    return password;
                }
                else
                {
                    // Email does not match username
                    return "Wachtwoord is niet verzonden, e-mail komt niet overeen met de gebruikersnaam.";
                }
            }
            else
            {
                // User does not exist
                return "Wachtwoord is niet verzonden, gebruiker bestaat niet.";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    #endregion

    #region ChangePassword
    /// <summary>
    /// Checks if current password (by user input) matches the password that is known in database, 
    /// if so it changes the password and returns a succes message, otherwise it returns a error message
    /// </summary>
    /// <param name="username"></param>
    /// <param name="Pcurrent"></param>
    /// <param name="Pnew"></param>
    /// <returns></returns>
    public static string ChangePassword(string username, string Pcurrent, string Pnew)
    {
        string query = string.Format("SELECT password FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            string dbPassword = command.ExecuteScalar().ToString();

            if (dbPassword == Pcurrent)     // Check if passwords match
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
    }
    #endregion

    #region ChangeEmail
    /// <summary>
    /// Checks if current e-mail (by user input) matches the e-mail that is known in database, 
    /// if so it changes the e-mail and returns a succes message, otherwise it returns a error message
    /// </summary>
    /// <param name="username"></param>
    /// <param name="Ecurrent"></param>
    /// <param name="Enew"></param>
    /// <returns></returns>
    public static string ChangeEmail(string username, string Ecurrent, string Enew)
    {
        string query = string.Format("SELECT email FROM users WHERE username = '{0}'", username);
        command.CommandText = query;

        try
        {
            conn.Open();
            string dbEmail = command.ExecuteScalar().ToString();

            if (dbEmail == Ecurrent)    // Check if e-mails match
            {
                // E- mails match
                query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", Enew);
                command.CommandText = query;

                int amountOfEmail = (int)command.ExecuteScalar();

                if (amountOfEmail < 1)      // Check if new e-mail is in use
                {
                    // E-mail NOT in use
                    query = string.Format("UPDATE users SET email = '{0}' WHERE username = '{1}'", Enew, username);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    return "Uw mail adres is aangepast!";
                }
                else
                {
                    // E-mail in use
                    return "Het nieuwe e-mail adres is al in gebruik!";
                }
            }
            else
            {
                // Emails do NOT match
                return "De huidige e-mail komt niet overeen!";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    #endregion
}