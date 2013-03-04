public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }

    public User(int id, string username, string password, string email, string type)
    {
        this.Id = id;
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.Type = type;
    }

    public User(string username, string password, string email, string type)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.Type = type;
    }
}
