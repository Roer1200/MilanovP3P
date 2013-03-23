public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cat_id { get; set; }
    public string Cname { get; set; } // Voor het omzetten van het cat_id in een naam.
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

    public Products(int id, string name, int cat_id, decimal price, string image, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Cat_id = cat_id;
        this.Price = price;
        this.Image = image;
        this.Description = description;
    }

    public Products(int id, string name, string cname, decimal price, string image, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Cname = cname;
        this.Price = price;
        this.Image = image;
        this.Description = description;
    }

    public Products(string name, int cat_id, decimal price, string image, string description)
    {
        this.Name = name;
        this.Cat_id = cat_id;
        this.Price = price;
        this.Image = image;
        this.Description = description;
    }
}