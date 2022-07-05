using Ditto.Application.Mediat.Category.Models;

namespace Ditto.Application.Mediat.Product.Models;

public class ProductModel
{
    public int Id { get; set;}
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public CategoryModel Category { get; set; }
}
