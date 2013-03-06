public class Users
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Typ_id { get; set; }

    public Users(int id, string username, string password, string email, int typ_id)
    {
        this.Id = id;
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.Typ_id = typ_id;
    }

    public Users(string username, string password, string email, int typ_id)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.Typ_id = typ_id;
    }
}