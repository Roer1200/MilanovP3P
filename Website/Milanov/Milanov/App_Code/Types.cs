public class Types
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Types(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public Types(string name)
    {
        this.Name = name;
    }
}
