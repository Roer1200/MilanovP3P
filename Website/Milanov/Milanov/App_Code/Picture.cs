public class Picture
{
    public int id { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public double price { get; set; }
    public string image { get; set; }
    public string description { get; set; }

    public Picture(int id, string name, string category, double price, string image, string description)
    {
        this.id = id;
        this.name = name;
        this.category = category;
        this.price = price;
        this.image = image;
        this.description = description;
    }
    public Picture(string name, string category, double price, string image, string description)
    {
        this.name = name;
        this.category = category;
        this.price = price;
        this.image = image;
        this.description = description;
    }
}