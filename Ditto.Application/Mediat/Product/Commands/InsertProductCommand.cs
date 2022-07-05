using Ditto.Application.Mediat.Product.Models;
using MediatR;

namespace Ditto.Application.Mediat.Product.Commands;

public class InsertProductCommand : IRequest<ProductModel>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
}
