public class Roles
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Roles(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public Roles(string name)
    {
        this.Name = name;
    }
}
