public class Categories
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Categories(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public Categories(string name)
    {
        this.Name = name;
    }
}