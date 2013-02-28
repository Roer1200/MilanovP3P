public class Picture
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

    public Picture(int id, string name, string category, double price, string image, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Category = category;
        this.Price = price;
        this.Image = image;
        this.Description = description;
    }
    public Picture(string name, string category, double price, string image, string description)
    {
        this.Name = name;
        this.Category = category;
        this.Price = price;
        this.Image = image;
        this.Description = description;
    }
}