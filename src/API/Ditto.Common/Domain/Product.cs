namespace Ditto.Common.Domain;

public class Product
{
    public int Id { get; set;}
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Ditto> Dittos { get; set; } = new HashSet<Ditto>();
}
