using MediatR;

namespace Ditto.Application.Mediat.Product.Commands;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set;}
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
}
