public class Type
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Type(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public Type(string name)
    {
        this.Name = name;
    }
}
